using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] private float _spawnInterval = 1f;
    [SerializeField] private Capsul _target;

    private void Start()
    {
        StartSpawning();
    }

    private void StartSpawning()
    {
        StartCoroutine(SpawnEnemies(_target));
    }

    private IEnumerator SpawnEnemies(Capsul target)
    {
        WaitForSecondsRealtime wait = new(_spawnInterval);

        while (enabled)
        {
            Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

            enemy.SetTarget(target.transform);

            enemy.StartMoving();

            yield return wait;
        }
    }
}