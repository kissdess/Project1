using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class CharacterMouseController : MonoBehaviour
{
    private Test playerInputs;
    private Camera mainCamera;
    private Coroutine moveCoroutine;

    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public LayerMask groundLayer;

    private void Awake()
    {
        playerInputs = new Test();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        playerInputs.Player.Click.started += OnLeftClickStarted;
        playerInputs.Player.Click.canceled += OnLeftClickCanceled;
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Player.Click.started -= OnLeftClickStarted;
        playerInputs.Player.Click.canceled -= OnLeftClickCanceled;
        playerInputs.Disable();
    }

    private void OnLeftClickStarted(InputAction.CallbackContext context)
    {
        if (moveCoroutine == null)
        {
            moveCoroutine = StartCoroutine(MoveCharacterCoroutine());
        }
    }

    private void OnLeftClickCanceled(InputAction.CallbackContext context)
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }
    }

    private IEnumerator MoveCharacterCoroutine()
    {
        while (true)
        {
            MoveCharacter();
            yield return null; // 다음 프레임까지 대기
        }
    }

    private void MoveCharacter()
    {
        Vector2 mousePosition = playerInputs.Player.MousePosition.ReadValue<Vector2>();
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = transform.position.y;

            Vector3 moveDirection = (targetPosition - transform.position).normalized;

            // 캐릭터 이동
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            // 캐릭터 회전
            if (moveDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }

            // 디버그: 이동 방향 표시
            Debug.DrawLine(transform.position, targetPosition, Color.red);
        }
    }
}