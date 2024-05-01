using System.Collections;
using UnityEngine;

public class PathDisplay : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private MoveContainer _moveContainer;
    private Vector3[] _actualPoints;

    private void Start()
    {
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

        _actualPoints = _moveContainer.PlayerPositions.ToArray();
    }

    private void SetActualPoints()
    {
        if (_actualPoints.Length == 0)
            return;
        _lineRenderer.positionCount = 0;
        _lineRenderer.positionCount = _actualPoints.Length;
        _lineRenderer.SetPositions(_actualPoints);
    }
}
