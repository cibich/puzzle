using System.Collections;
using UnityEngine;

public class TwinMovement : MonoBehaviour, IMovable
{
    [SerializeField] private GameStateHandler _gameStateHandler;
    [SerializeField] private TwinMovePoints _movePoints;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private TriggerHandler _triggerHandler;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Vector2 _direction;
    public bool IsMoving { get; set; } = false;

    public void Move()
    {
        if (IsMoving)
        {
            Vector2 direction = (_direction - _rb.position).normalized;

            if (Vector2.Distance(_rb.position, _direction) <= 0.1f)
                SetNextTarget();
            else
                _rb.velocity = direction * _speed;
        }
        else
            _rb.velocity = Vector2.zero;
    }

    private void OnEnable()
    {
        _triggerHandler.OnBoostSpeed += ChangeMovespeed;
        UserInput.OnPressF += StartMoving;
    }

    private void OnDisable()
    {
        _triggerHandler.OnBoostSpeed -= ChangeMovespeed;
        UserInput.OnPressF -= StartMoving;
    }

    private void FixedUpdate() => Move();

    private void ChangeMovespeed(float multiplier) => StartCoroutine(ChangeSpeed(multiplier));

    private void StartMoving()
    {
        if (_movePoints.MovePoints.Count > 0)
        {
            _direction = _movePoints.MovePoints.Pop();
            IsMoving = true;
        }
    }

    IEnumerator ChangeSpeed(float multiplier)
    {
        float defaultSpeed = _speed;
        _speed *= multiplier;
        yield return new WaitForSeconds(1f);
        _speed = defaultSpeed;
    }

    private void SetNextTarget()
    {
        if (_movePoints.MovePoints.Count > 0)
            _direction = _movePoints.MovePoints.Pop();
        else
            IsMoving = false;
    }
}
