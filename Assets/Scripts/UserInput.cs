using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public static Action OnPressF;
    [SerializeField] private TriggerHandler _playerTriggerHandler;
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private IDirectionInput _player;
    private bool _playerIsFinished = false;

    private void OnEnable() => _playerTriggerHandler.OnFinishing += () => _playerIsFinished = true;

    private void OnDisable() => _playerTriggerHandler.OnFinishing -= () => _playerIsFinished = true;

    private void Start() => _player = FindObjectOfType<PlayerMovement>().GetComponent<IDirectionInput>();

    private void Update()
    { 
        _player.Direction = new Vector2(Input.GetAxis(HORIZONTAL), Input.GetAxis(VERTICAL));

        if (Input.GetKeyDown(KeyCode.F) && _playerIsFinished)
        {
            _playerIsFinished = false;
            OnPressF?.Invoke();
        }
    }
}
