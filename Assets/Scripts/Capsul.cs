using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Transform))]
public class Capsul : MonoBehaviour
{
    [SerializeField] private Mover _mover;

    private Renderer _renderer;
    private Color _baseColor = Color.yellow;

    private void Start()
    {
        StartMoving();
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = _baseColor;
    }

    private void StartMoving()
    {
        _mover.StartMove(transform);
    }
}