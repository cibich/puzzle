using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public Action OnGameOver;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.ENEMY))
            OnGameOver?.Invoke();
    }
}
