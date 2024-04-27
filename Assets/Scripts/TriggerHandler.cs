using System;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public Action<float> OnBoostSpeed;
    public Action<Vector2> OnMirrorTouch;
    public Action OnFinishing;

    private float _accelerationMultiplier = 2f;
    private float _slowMultiplier = 0.2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.BOOSTSPEED))
            OnBoostSpeed?.Invoke(_accelerationMultiplier);
        if (collision.CompareTag(Tags.SLOWSPEED))
            OnBoostSpeed?.Invoke(_slowMultiplier);
        if (collision.CompareTag(Tags.MIRROR))
            OnMirrorTouch?.Invoke(Vector2.left);
        if (collision.CompareTag(Tags.FINISH))
            OnFinishing?.Invoke();

    }
}
