using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveContainer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private float _interval = 0.1f;
    private bool _isRecording = true;
    public Stack<Vector3> PlayerPositions { get; private set; }
    public float Duration { get; private set; }

    private void OnEnable() => UserInput.OnPressF += FinishRecording;

    private void OnDisable() => UserInput.OnPressF -= FinishRecording;

    private void FinishRecording() => _isRecording = false;

    private void Start()
    {
        PlayerPositions = new Stack<Vector3>();
        PlayerPositions.Push(_player.position);
        StartCoroutine(RecordPlayerPosition());
    }

    IEnumerator RecordPlayerPosition()
    {
        WaitForSeconds wait = new WaitForSeconds(_interval);
        while (_isRecording)
        {
            Debug.Log(PlayerPositions.Count);
            if (Vector3.Distance(_player.position, PlayerPositions.Peek()) > 0.1f)
                PlayerPositions.Push(_player.position);
            yield return wait;
        }
        yield break;
    }
}
