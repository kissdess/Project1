using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    [SerializeField]
    protected Define.State _state = Define.State.Idle;
    [SerializeField]
    protected GameObject _lockTarget;

    protected Vector3 _destPos;

    protected Animator _animator;

    public Define.WorldObject WorldObjectType { get; protected set; } = Define.WorldObject.Unknown;

    public virtual Define.State State
    {
        get { return _state; }
        set
        {
            _state = value;
            UpdateAnimation(_state);
        }
    }

    protected virtual void Start()
    {
        Init();
        _animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        switch (State)
        {
            case Define.State.Die:
                UpdateDie();
                break;
            case Define.State.Idle:
                UpdateIdle();
                break;
            case Define.State.Moving:
                UpdateMoving();
                break;
            case Define.State.Skill:
                UpdateSkill();
                break;
        }
    }

    public abstract void Init();

    protected virtual void UpdateAnimation(Define.State state)
    {
        if (_animator == null)
            return;

        switch (state)
        {
            case Define.State.Die:
                _animator.CrossFade("DIE", 0.1f, 0);
                break;
            case Define.State.Idle:
                _animator.CrossFade("WAIT", 0.1f, -1, 0);
                break;
            case Define.State.Moving:
                if (gameObject.name.Contains("Player"))
                    _animator.Play("RUN", 0);
                else
                    _animator.CrossFade("RUN", 0.1f, -1, 0);
                break;
            case Define.State.Skill:
                _animator.CrossFade("ATTACK", 0.1f, -1, 0);
                break;
        }
    }

    protected virtual void UpdateDie() { }
    protected virtual void UpdateIdle() { }
    protected virtual void UpdateMoving() { }
    protected virtual void UpdateSkill() { }
}