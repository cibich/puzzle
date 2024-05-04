using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public static Action OnPressF;
    [SerializeField] private GameStateHandler _gameStateHandler;
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private IDirectionInput _player;
    private bool _playerIsFinished = false;

    private void OnEnable() => _gameStateHandler.OnPlayerFinished += () => _playerIsFinished = true;

    private void OnDisable() => _gameStateHandler.OnPlayerFinished -= () => _playerIsFinished = false;

    private void Start() => _player = FindObjectOfType<PlayerMovement>().GetComponent<IDirectionInput>();

    private void Update()
    { 
        _player.Direction = new Vector2(Input.GetAxis(HORIZONTAL), Input.GetAxis(VERTICAL));

        Debug.Log(_playerIsFinished);
        if (Input.GetKeyDown(KeyCode.F) && _playerIsFinished)
        {
            OnPressF?.Invoke();
            _playerIsFinished = false;
        }
    }
}
