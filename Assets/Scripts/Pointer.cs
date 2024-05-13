using System.Collections;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private float _delay = 5f;

    private void Start() => StartCoroutine(StartDestroyCoroutine());

    private IEnumerator StartDestroyCoroutine()
    {
        yield return new WaitForSeconds(_delay);
        Destroy(this.gameObject);
    }
}
