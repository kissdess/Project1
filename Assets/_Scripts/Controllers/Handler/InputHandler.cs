using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] PlayerUI = new GameObject[2];
    private PlayerController _playerController;
    private int _mask;
    private bool _isInventoryOpen = false;
    private bool _isDraggingItem = false;


    public void Initialize(PlayerController playerController)
    {
        _playerController = playerController;
        _mask = (1 << (int)Define.Layer.Ground) | (1 << (int)Define.Layer.Monster) | (1 << (int)Define.Layer.Box) | (1 << (int)Define.Layer.Wall);

        Managers.Input.MouseAction -= OnMouseEvent;
        Managers.Input.MouseAction += OnMouseEvent;
        Managers.Input.KeyAction -= OnKeyEvent;
        Managers.Input.KeyAction += OnKeyEvent;

    }

    public void SetDraggingItemState(bool isDragging)
    {
        _isDraggingItem = isDragging;
    }

    public void OnMouseEvent(Define.MouseEvent evt)
    {
        if (_isDraggingItem)
        {
            _playerController.State = Define.State.Idle;
            return;
        }

        // 스킬 사용 중일 때의 처리
        if (_playerController.State == Define.State.Skill)
        {
            if (evt == Define.MouseEvent.PointerUp)
            {
                _playerController.StopSkill = true;
            }
            return;
        }

        // Idle 또는 Moving 상태일 때 마우스 이벤트 처리
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
        if (_playerController.LockTarget == null)
        {
            _playerController.State = Define.State.Idle;
        }
        _playerController.StopSkill = true;
    }

    private void OnKeyEvent()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (PlayerUI != null)
            {
                _isInventoryOpen = !_isInventoryOpen;
                PlayerUI[(int)Define.Interfaces.Inventory].SetActive(_isInventoryOpen);
                PlayerUI[(int)Define.Interfaces.Equipment].SetActive(_isInventoryOpen);
            }
            else
            {
                Debug.LogError("InventoryUI is not assigned in the Inspector!");
            }
        }
    }


}