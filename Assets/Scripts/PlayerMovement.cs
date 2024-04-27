using System.Collections;
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
        _triggerHandler.OnMirrorTouch += Revert;
        _triggerHandler.OnFinishing += () => IsMoving = false;
    }

    private void OnDisable()
    {
        _triggerHandler.OnMirrorTouch -= Revert;
        _triggerHandler.OnFinishing -= () => IsMoving = false;
    }

    private void Revert(Vector2 vector) => StartCoroutine(RevertCoroutine(vector));

    IEnumerator RevertCoroutine(Vector2 vector)
    {
        Debug.Log("Revert Coroutine");
        IsMoving = false;
        _rb.AddForce(vector * 3000);
        yield return new WaitForSeconds(1f);
        _rb.velocity = Vector2.zero;
        IsMoving = true;
    }

    public void Move()
    {
        if (IsMoving) _rb.velocity = Direction * _speed;
        else _rb.velocity = Vector2.zero;
    }

    private void FixedUpdate() => Move();
}
