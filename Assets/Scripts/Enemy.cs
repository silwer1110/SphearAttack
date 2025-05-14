using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Color _baseColor;

    private Renderer _renderer;
    private Vector3 _target;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = _baseColor;
    }

    public void SetTarget(Vector3 targetPosition)
    {
        _target = targetPosition;
    }

    public void StartMoving()
    {
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        while ((transform.position - _target).sqrMagnitude > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

            yield return null;
        }

        Destroy(gameObject);
    }
}