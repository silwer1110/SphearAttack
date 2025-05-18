using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private int _positionNumber = 0;

    public void StartMove(Transform transform)
    {
        StartCoroutine(Move(transform));
    }

    private IEnumerator Move(Transform transform)
    {
        PlaceOnStartPosition(transform);

        while (enabled)
        {
            Vector3 nextPosition = _waypoints[_positionNumber].position;

            if ((transform.position - nextPosition).sqrMagnitude > 0.0001f)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextPosition, _speed * Time.deltaTime);
            }
            else
            {
                transform.position = nextPosition;
                _positionNumber = GetNextIndex(_positionNumber);
            }

            yield return null;
        }
    }

    private void PlaceOnStartPosition(Transform transform)
    {
        _positionNumber = GetPositionNumber(_positionNumber);

        transform.position = _waypoints[_positionNumber].position;
        _positionNumber = GetNextIndex(_positionNumber);
    }

    private int GetPositionNumber(int number)
    {
        _positionNumber--;

        if (number < 0)
        {
            _positionNumber = 0;
        }
        else if (number >= _waypoints.Length)
        {
            _positionNumber = _waypoints.Length - 1;
        }

        return _positionNumber;
    }

    private int GetNextIndex(int index)
    {
        int nextIndex;

        nextIndex = (index + 1) % _waypoints.Length;

        return nextIndex;
    }
}