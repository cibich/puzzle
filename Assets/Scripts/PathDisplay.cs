using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDisplay : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private MoveContainer _moveContainer;
    [SerializeField] private bool _isReverse;
    private List<Vector3> _actualPoints;

    private void Start()
    {
        _actualPoints = new List<Vector3>();
        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        while (true)
        {
            yield return wait;
            GetActualPoints();
            SetActualPoints();
        }
    }

    private void GetActualPoints()
    {
        if (_moveContainer.PlayerPositions.Count == 0)
            return;
        if (_isReverse)
            GetReversePoints();
        else
            _actualPoints.AddRange(_moveContainer.PlayerPositions.ToArray());
    }

    private void SetActualPoints()
    {
        if (_actualPoints.Count == 0)
            return;
        _lineRenderer.positionCount = 0;
        _lineRenderer.positionCount = _actualPoints.Count;
        _lineRenderer.SetPositions(_actualPoints.ToArray());
        _actualPoints.Clear();
    }

    private void GetReversePoints()
    {
        foreach (var pos in _moveContainer.PlayerPositions)
        {
            _actualPoints.Add(new Vector3(-pos.x, -pos.y, pos.z));
        }
    }
}
