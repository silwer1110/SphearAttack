using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 5f;

    private int _currentIndex = 0;

    public void StartMove(Transform transform)
    {
        StartCoroutine(Move(transform));
    }

    private IEnumerator Move(Transform transform)
    {
        PlaceOnStartPosition(transform);

        while (enabled)
        {
            Vector3 nextPosition = _waypoints[_currentIndex].position;

            if ((transform.position - nextPosition).sqrMagnitude > 0.0001f)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextPosition, _speed * Time.deltaTime);
            }
            else
            {
                transform.position = nextPosition;
                _currentIndex = GetNextIndex(_currentIndex);
            }

            yield return null;
        }
    }

    private void PlaceOnStartPosition(Transform transform)
    {
        transform.position = _waypoints[_currentIndex].position;
        _currentIndex = GetNextIndex(_currentIndex);
    }

    private int GetNextIndex(int index)
    {
        int nextIndex;

        nextIndex = (index + 1) % _waypoints.Length;

        return nextIndex;
    }
}