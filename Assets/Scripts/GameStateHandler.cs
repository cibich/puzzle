using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    public Action OnGameOver;
    public Action OnPlayerFinished;
    public Action OnRoundCompleted;

    [SerializeField] private CollisionHandler _playerCollisionHandler;
    [SerializeField] private CollisionHandler _twinCollisionHandler;
    [SerializeField] private TriggerHandler _playerTriggerHandler;
    [SerializeField] private TriggerHandler _twinTriggerHandler;
    private List<IMovable> _movableObjects = new List<IMovable>();

    private void Start()
    {
        GameObject[] objects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj.GetComponent<IMovable>() != null)
                _movableObjects.Add(obj.GetComponent<IMovable>());
        }
    }

    private void OnEnable()
    {
        _playerCollisionHandler.OnGameOver += GameOver;
        _twinCollisionHandler.OnGameOver += GameOver;
        _playerTriggerHandler.OnFinishing += PlayerIsFinished;
        _twinTriggerHandler.OnFinishing += RoundCompleted;
    }

    private void OnDisable()
    {
        _playerCollisionHandler.OnGameOver -= GameOver;
        _twinCollisionHandler.OnGameOver -= GameOver;
        _playerTriggerHandler.OnFinishing += PlayerIsFinished;
        _twinTriggerHandler.OnFinishing -= RoundCompleted;
    }

    private void PlayerIsFinished() => OnPlayerFinished?.Invoke();

    private void RoundCompleted()
    {
        StopAllMoves();
        OnRoundCompleted?.Invoke();
    }

    private void GameOver()
    {
        StopAllMoves();
        OnGameOver?.Invoke();
    }

    private void StopAllMoves()
    {
        foreach (IMovable obj in _movableObjects)
            obj.IsMoving = false;
    }
}
