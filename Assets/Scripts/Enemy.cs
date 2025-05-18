using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private Color _baseColor;

    private Renderer _renderer;
    private Transform _target;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = _baseColor;
    }

    public void SetTarget(Transform capsulPosition)
    {
        _target = capsulPosition;
    }

    public void StartMoving()
    {
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        float distanceToTarget = 0.1f;

        while ((transform.position - _target.position).sqrMagnitude > distanceToTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

            yield return null;
        }

        Destroy(gameObject);
    }
}