using UnityEngine;
using UnityEngine.AI;

public class MonsterController : BaseController
{
    private Stat _stat;
    private DropItem DropItem;

    [SerializeField]
    private float _scanRange = 10;
    [SerializeField]
    private float _attackRange = 2;
    [SerializeField]
    public GameObject[] DropItems = new GameObject[3];

    public bool _isDropped = false;

    public override void Init()
    {
        WorldObjectType = Define.WorldObject.Monster;
        _stat = gameObject.GetComponent<Stat>();

        if (gameObject.GetComponentInChildren<UI_HpBar>() == null)
            Managers.UI.MakeWorldSpaceUI<UI_HpBar>(transform);

        DropItem = gameObject.GetComponent<DropItem>();
    }


    protected override void UpdateIdle()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            return;

        float distance = (player.transform.position - transform.position).magnitude;
        if (distance <= _scanRange)
        {
            _lockTarget = player;
            State = Define.State.Moving;
            return;
        }

        if (_stat.Hp <= 0)
            State = Define.State.Die;

    }

    protected override void UpdateMoving()
    {
        // 플레이어가 내 사정거리보다 가까우면 공격
        if (_lockTarget != null)
        {
            _destPos = _lockTarget.transform.position;
            float distance = (_destPos - transform.position).magnitude;

            if (distance <= _attackRange && _lockTarget.CompareTag("Player"))
            {
                NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
                nma.SetDestination(transform.position);
                State = Define.State.Skill;
                return;
            }
        }

        // 이동

        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.1f)
        {
            State = Define.State.Idle;
        }
        else
        {
            NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
            nma.SetDestination(_destPos);
            nma.speed = _stat.MoveSpeed;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }

        if (_stat.Hp <= 0)
            UpdateDie();

    }

    protected override void UpdateDie()
    {
        gameObject.layer = (int)Define.Layer.Dead;
        if (!DropItem.IsDropped)
            DropItem.DropTable();
    }

    protected override void UpdateSkill()
    {
        if (_lockTarget != null)
        {
            Vector3 dir = _lockTarget.transform.position - transform.position;
            Quaternion quat = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
        }
        if (_stat.Hp <= 0)
            State = Define.State.Die;
    }

    void OnHitEvent()
    {
        if (_lockTarget != null)
        {
            Stat targetStat = _lockTarget.GetComponent<Stat>();
            Stat myStat = gameObject.GetComponent<Stat>();
            targetStat.OnAttacked(_stat);

            if (targetStat.Hp > 0)
            {
                float distance = (_lockTarget.transform.position - transform.position).magnitude;
                if (distance <= _attackRange)
                    State = Define.State.Skill;
                else
                    State = Define.State.Moving;
            }
            else
            {
                State = Define.State.Idle;
            }
        }
        else
        {
            State = Define.State.Idle;
        }
        return;
    }

}
