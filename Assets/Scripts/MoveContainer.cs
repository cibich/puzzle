using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveContainer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private float _interval = 0.2f;
    private bool _isRecording = true;
    public Queue<Vector2> PlayerPositions { get; private set; }
    public float Duration { get; private set; }

    private void OnEnable() => UserInput.OnPressF += FinishRecording;

    private void OnDisable() => UserInput.OnPressF -= FinishRecording;

    private void FinishRecording() => _isRecording = false;

    private void Start()
    {
        PlayerPositions = new Queue<Vector2>();
        PlayerPositions.Enqueue(_player.position);
        StartCoroutine(RecordPlayerPosition());
    }

    IEnumerator RecordPlayerPosition()
    {
        WaitForSeconds wait = new WaitForSeconds(_interval);
        while (_isRecording)
        {
            if ((Vector2)_player.position != PlayerPositions.Peek())
                PlayerPositions.Enqueue(_player.position);
            yield return wait;
        }
    }
}
