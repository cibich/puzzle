using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public static Action OnPressF;
    [SerializeField] private TriggerHandler _triggerHandler;
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private IDirectionInput _player;

    private void Start() => _player = FindObjectOfType<PlayerMovement>().GetComponent<IDirectionInput>();

    private void Update()
    { 
        _player.Direction = new Vector2(Input.GetAxis(HORIZONTAL), Input.GetAxis(VERTICAL));

        if (Input.GetKeyDown(KeyCode.F))
        {
            OnPressF?.Invoke();
        }
    }
}
