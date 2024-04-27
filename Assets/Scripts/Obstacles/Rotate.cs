using UnityEngine;

public class Rotate : MonoBehaviour, IMovable
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private int _direction;

    public bool IsMoving { get; set; } = true;

    public void Move()
    {
        if (IsMoving)
            _rb.angularVelocity = _direction * _speed;
        else _rb.angularVelocity = 0;
    }

    private void FixedUpdate() => Move();
}
