using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Capsul : MonoBehaviour
{
    [SerializeField] private Mover _mover;

    private Renderer _renderer;
    private Color _baseColor = Color.yellow;

    public event Action<Vector3> OnPosition;

    private Transform _transform;   

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _transform = GetComponent<Transform>();
        _renderer.material.color = _baseColor;

        StartCoroutine(GetCurrentPosition());
    }
    public void StartMoving()
    {
        _mover.StartMove(_transform);
    }

    private IEnumerator GetCurrentPosition() 
    {
        while (enabled) 
        {
            OnPosition?.Invoke(_transform.position);

            yield return null;
        }
    }
}