using System.Collections.Generic;
using UnityEngine;

public class TwinMovePoints : MonoBehaviour
{
    [SerializeField] private bool _isReverseMove;
    [SerializeField] private GameStateHandler _gameStateHandler;
    [SerializeField] private MoveContainer _playerMoves;
    public Stack<Vector3> MovePoints { get; private set; } = new Stack<Vector3>();

    private void OnEnable() => _gameStateHandler.OnPlayerFinished += InitializeMovePoints;

    private void OnDisable() => _gameStateHandler.OnPlayerFinished -= InitializeMovePoints;

    private void InitializeMovePoints()
    {
        if (_isReverseMove)
            InitializeReverseMovePoints();
        else InitializeDefaultMovePoints();
    }

    private void InitializeDefaultMovePoints()
    {
        if (_playerMoves.PlayerPositions.Count > 0)
        {
            foreach (var position in _playerMoves.PlayerPositions)
                MovePoints.Push(position);
        }
    }

    private void InitializeReverseMovePoints()
    {
        if (_playerMoves.PlayerPositions.Count > 0)
        {
            foreach (var position in _playerMoves.PlayerPositions)
                MovePoints.Push(new Vector3(-position.x, -position.y, position.z));
        }
    }
}
