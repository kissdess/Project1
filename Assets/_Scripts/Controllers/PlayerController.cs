using UnityEngine;
using System.Collections.Generic;

public class PlayerController : BaseController
{
    [SerializeField] private PlayerStat _stat;
    [SerializeField] private List<Slashes> _slashes;

    public bool StopSkill { get; set; } = false;

    private CharacterController _characterController;
    private InputHandler _inputHandler;
    private MovementHandler _movementHandler;
    private CombatHandler _combatHandler;

    public Vector3 DestPos => _destPos;
    public GameObject LockTarget => _lockTarget;

    public override void Init()
    {

        WorldObjectType = Define.WorldObject.Player;

        InitializeComponents();
        InitializeHandlers();
        InitializeUI();
    }

    private void InitializeComponents()
    {
        _stat = GetComponent<PlayerStat>();
        _characterController = GetComponent<CharacterController>();
    }

    private void InitializeHandlers()
    {
        _inputHandler = GetComponent<InputHandler>();
        _inputHandler.Initialize(this);

        _movementHandler = GetComponent<MovementHandler>();
        _movementHandler.Initialize(this, _characterController, _stat);

        _combatHandler = GetComponent<CombatHandler>();
        _combatHandler.Initialize(this, _stat, _slashes);
    }

    private void InitializeUI()
    {
        if (GetComponentInChildren<UI_HpBar>() == null)
            Managers.UI.MakeWorldSpaceUI<UI_HpBar>(transform);
    }

    protected override void UpdateMoving()
    {
        if (_lockTarget != null && _movementHandler.IsInInteractionRange(_lockTarget.transform.position))
        {
            State = Define.State.Skill;
            return;
        }

        _movementHandler.MoveTowards(_destPos);

        if (Vector3.Distance(transform.position, _destPos) < _movementHandler.StopDistance)
        {
            State = Define.State.Idle;
        }
    }

    protected override void UpdateSkill()
    {
        if (_lockTarget != null)
        {
            _movementHandler.RotateTowardsTarget(_lockTarget.transform.position);

            if (!_combatHandler.IsAttacking && _movementHandler.IsInInteractionRange(_lockTarget.transform.position))
            {
                StartCoroutine(_combatHandler.PerformAttack());
            }
        }
        else
        {
            State = Define.State.Idle;
        }
    }

    public void SetDestination(Vector3 destPos)
    {
        _destPos = destPos;
        State = Define.State.Moving;
    }

    public void SetLockTarget(GameObject target)
    {
        _lockTarget = target;
        if (_lockTarget != null)
        {
            SetDestination(_lockTarget.transform.position);
        }
    }

    public void OnHitEvent()
    {
        if (_lockTarget != null)
        {
            if (_combatHandler.AttackTarget(_lockTarget))
            {
                _lockTarget = null;
                State = Define.State.Idle;
                return;
            }
        }

        State = StopSkill ? Define.State.Idle : Define.State.Skill;
    }

    public void OnMouseEvent(Define.MouseEvent evt)
    {
        switch (State)
        {
            case Define.State.Idle:
            case Define.State.Moving:
                _inputHandler.OnMouseEvent(evt);
                break;
            case Define.State.Skill:
                if (evt == Define.MouseEvent.PointerUp)
                    StopSkill = true;
                break;
        }
    }

    public void StopCurrentAction()
    {
        StopSkill = true;
        State = Define.State.Idle;
    }
}

