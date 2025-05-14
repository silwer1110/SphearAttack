using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] CapsulSpawner _capsulSpawner;
    [SerializeField] private float _spawnInterval = 1f;

    private void OnEnable()
    {
        _capsulSpawner.Spawned += StartSpawning;
    }

    private void OnDisable()
    {
        _capsulSpawner.Spawned -= StartSpawning;
    }

    private void StartSpawning(CapsulList capsuls)
    {
        StartCoroutine(SpawnEnemies(capsuls.GetRandomCapsul()));
    }

    private IEnumerator SpawnEnemies(Capsul target)
    {
        WaitForSecondsRealtime wait = new(_spawnInterval);

        while (enabled)
        {
            Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

            target.OnPosition += enemy.SetTarget;

            enemy.StartMoving();

            yield return wait;
        }
    }
}