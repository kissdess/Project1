using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    private PlayerController _playerController;
    private int _mask;

    public void Initialize(PlayerController playerController)
    {
        _playerController = playerController;
        _mask = (1 << (int)Define.Layer.Ground) | (1 << (int)Define.Layer.Monster) | (1 << (int)Define.Layer.Box) | (1 << (int)Define.Layer.Wall);

        Managers.Input.MouseAction -= OnMouseEvent;
        Managers.Input.MouseAction += OnMouseEvent;
    }

    public void OnMouseEvent(Define.MouseEvent evt)
    {
        if (_playerController.State == Define.State.Skill)
        {
            if (evt == Define.MouseEvent.PointerUp)
                _playerController.StopSkill = true;
            return;
        }

        if (_playerController.State == Define.State.Idle || _playerController.State == Define.State.Moving)
        {
            OnMouseEvent_IdleRun(evt);
        }
    }

    private void OnMouseEvent_IdleRun(Define.MouseEvent evt)
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100.0f, _mask))
        {
            switch (evt)
            {
                case Define.MouseEvent.PointerDown:
                    HandlePointerDown(hit);
                    break;
                case Define.MouseEvent.Press:
                    HandlePress(hit);
                    break;
                case Define.MouseEvent.PointerUp:
                    HandlePointerUp(hit);
                    break;
            }
        }
    }

    private void HandlePointerDown(RaycastHit hit)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            _playerController.State = Define.State.Idle;
            return;
        }

        _playerController.State = Define.State.Moving;
        _playerController.SetDestination(hit.point);
        _playerController.StopSkill = false;
        _playerController.SetLockTarget(hit.collider.gameObject.layer == (int)Define.Layer.Monster ? hit.collider.gameObject : null);
    }

    private void HandlePress(RaycastHit hit)
    {
        if (_playerController.LockTarget == null)
        {
            _playerController.SetDestination(hit.point);
        }
    }

    private void HandlePointerUp(RaycastHit hit)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            _playerController.State = Define.State.Idle;
        }

        if (_playerController.LockTarget == null)
        {
            _playerController.State = Define.State.Idle;
        }
        _playerController.StopSkill = true;
    }
}