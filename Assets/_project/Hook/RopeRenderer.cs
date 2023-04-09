using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private int _segments = 10;
    

    
    public void Draw(Vector3 startPosition, Vector3 endPosition, float length)
    {
        _lineRenderer.enabled = true;
        float interpolant = Vector3.Distance(startPosition, endPosition) / length;

        float offset = Mathf.Lerp(length / 2f, 0f, interpolant);

        Vector3 startDownPosition = startPosition + Vector3.down * offset;
        Vector3 endDownPosition = endPosition + Vector3.down * offset;

        _lineRenderer.positionCount = _segments + 1;
        for (int i = 0; i < _segments + 1; i++)
        {
            _lineRenderer.SetPosition(i, Bezier.GetPoint(startPosition, startDownPosition, endDownPosition, endPosition,(float)i / _segments));
        }
    }

    public void Hide()
    {
        _lineRenderer.enabled = false;
    }
}
