using UnityEngine;

[RequireComponent( typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private Color _baseColor = Color.red;
    private Renderer _renderer;
    private Vector3 _moveDiretion;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        SetColor();
    }

    private void Update()
    {
        Move();
    }

    public void SetDirection(Vector3 direction)
    {
        _moveDiretion = direction;
    }

    private void Move()
    {
        transform.position += _moveDiretion * _speed * Time.deltaTime;
    }

    private void SetColor()
    {
        _renderer.material.color = _baseColor;
    }
}