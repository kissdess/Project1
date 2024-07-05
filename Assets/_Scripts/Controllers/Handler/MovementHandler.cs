using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    public float InteractionDistance { get; set; } = 1.5f;
    public float StopDistance { get; set; } = 0.1f;

    private PlayerController _playerController;
    private CharacterController _characterController;
    private PlayerStat _stat;

    private Vector3 _moveDirection = Vector3.zero;
    private float _verticalVelocity = 0;

    public void Initialize(PlayerController playerController, CharacterController characterController, PlayerStat stat)
    {
        _playerController = playerController;
        _characterController = characterController;
        _stat = stat;
    }

    public bool IsInInteractionRange(Vector3 targetPosition)
    {
        return Vector3.Distance(_playerController.transform.position, targetPosition) <= InteractionDistance;
    }

    public void MoveTowards(Vector3 destination)
    {
        Vector3 dir = destination - _playerController.transform.position;
        dir.y = 0;

        if (dir != Vector3.zero)
        {
            if (dir.magnitude < StopDistance)
            {
                return;
            }

            ApplyMovement(dir);
            RotateTowardsDirection(dir);
        }
    }

    public void RotateTowardsTarget(Vector3 targetPosition)
    {
        Vector3 dir = targetPosition - _playerController.transform.position;
        dir.y = 0;
        if (dir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            _playerController.transform.rotation = Quaternion.Lerp(_playerController.transform.rotation, targetRotation, 20 * Time.deltaTime);
        }
    }

    private void ApplyMovement(Vector3 direction)
    {
        _moveDirection = direction.normalized * _stat.MoveSpeed;

        ApplyGravity();

        _characterController.Move(_moveDirection * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (_characterController.isGrounded)
        {
            _verticalVelocity = -0.5f;
        }
        else
        {
            _verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        _moveDirection.y = _verticalVelocity;
    }

    private void RotateTowardsDirection(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _playerController.transform.rotation = Quaternion.Lerp(_playerController.transform.rotation, targetRotation, 20 * Time.deltaTime);
        }
    }
}