using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable, IDirectionInput
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private TriggerHandler _triggerHandler;
    private float _speed = 2f;
    public bool IsMoving { get; set; } = true;
    public Vector2 Direction { get; set; }

    private void OnEnable()
    {
        _triggerHandler.OnFinishing += () => IsMoving = false;
    }

    private void OnDisable()
    {
        _triggerHandler.OnFinishing -= () => IsMoving = false;
    }

    public void Move()
    {
        if (IsMoving) _rb.velocity = Direction * _speed;
        else _rb.velocity = Vector2.zero;
    }

    private void FixedUpdate() => Move();
}
