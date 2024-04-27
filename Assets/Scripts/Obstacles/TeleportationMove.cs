using System.Collections;
using UnityEngine;

public class TeleportationMove : MonoBehaviour, IMovable
{
    private const float INTERVAL = 2f;
    [SerializeField] private Vector2 _offset;
    private Vector2 _originalPosition;
    public Vector2 _maxOffset;
    public bool IsMoving { get; set; } = true;

    private void Start()
    {
        _originalPosition = transform.position;
        _maxOffset = _originalPosition + _offset * 4;
        Move();
    }

    private void Update()
    {
        if (IsMoving == false)
            StopCoroutine(Teleport());
    }

    public void Move() => StartCoroutine(Teleport());

    IEnumerator Teleport()
    {
        WaitForSeconds wait = new WaitForSeconds(INTERVAL);
        while (IsMoving)
        {
            yield return wait;
            if (Vector2.Distance((Vector2)transform.position + _offset, _maxOffset) > 0.1f)
                transform.position = (Vector2)transform.position + _offset;
            else transform.position = _originalPosition;
        }
    }
}
