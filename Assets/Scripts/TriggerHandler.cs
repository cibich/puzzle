using System;
using System.Collections;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public Action<float> OnBoostSpeed;
    public Action OnFinishing;

    private float _accelerationMultiplier = 2f;
    private float _slowMultiplier = 0.2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.BOOSTSPEED))
            OnBoostSpeed?.Invoke(_accelerationMultiplier);
        if (collision.CompareTag(Tags.SLOWSPEED))
            OnBoostSpeed?.Invoke(_slowMultiplier);
        if (collision.CompareTag(Tags.FINISH))
            StartCoroutine(DelayedNotification());
    }

    IEnumerator DelayedNotification()
    {
        yield return new WaitForSeconds(0.2f);
        OnFinishing?.Invoke();
    }
}
