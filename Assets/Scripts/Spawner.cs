using System.Collections;
using UnityEngine;

public class Spawner: MonoBehaviour
{
    [SerializeField] Transform[] _spawnPositions;
    [SerializeField] Enemy _enemyPrefab;

    private float _spawnInterval = 2f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies(_spawnInterval));
    }

    IEnumerator SpawnEnemies(float delay)
    {
        WaitForSecondsRealtime wait = new(delay);

        while (enabled)
        {
            yield return wait;

            Enemy enemy = Instantiate(_enemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);

            enemy.SetDirection(GetRandomDirection());
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return _spawnPositions[UnityEngine.Random.Range(0, _spawnPositions.Length)].position;
    }

    private Vector3 GetRandomDirection()
    {
        Vector3[] directions = {

            Vector3.right,
            Vector3.left,
            Vector3.back,
            Vector3.forward
        };

        return directions[UnityEngine.Random.Range(0, directions.Length)];
    }
}