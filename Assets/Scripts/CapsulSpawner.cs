using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CapsulSpawner : MonoBehaviour
{
    [SerializeField] private Capsul _capsulPrefab;
    [SerializeField] private CapsulList _capsuls;
    [SerializeField] private float _delay = 2f;

    private int _capsulCount = 7;

    public event UnityAction<CapsulList> Spawned;

    private void Start()
    {
        StartCreating();
    }

    private void StartCreating()
    {
        StartCoroutine(Create(_delay));
    }

    private IEnumerator Create(float delay)
    {
        WaitForSeconds wait = new(delay);

        for (int i = 0; i < _capsulCount; i++)
        {
            Capsul capsul;

            capsul = Instantiate(_capsulPrefab);

            _capsuls.Add(capsul);

            capsul.StartMoving();

            yield return wait;
        }

        Spawned?.Invoke(_capsuls);
    }
}