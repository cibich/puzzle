using UnityEngine;

public class PatrolMove : MonoBehaviour, IMovable
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector2 _pointA;
    [SerializeField] private Vector2 _pointB;
    [SerializeField] private float _speed;
    private Vector2 _target;
    public bool IsMoving { get; set; } = true;

    public void Move()
    {
        if (IsMoving)
        {
            if (Vector2.Distance(_rb.position, _target) <= 0.1f)
                _target = _target == _pointA ? _pointB : _pointA;
            else _rb.velocity = (_target - _rb.position).normalized * _speed;
        }
        else _rb.velocity = Vector2.zero;
    }

    private void Start()
    {
        _pointA = transform.position;
        _target = _pointB;
    }

    private void FixedUpdate() => Move();
}
