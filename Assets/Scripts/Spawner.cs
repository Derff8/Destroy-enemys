using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private DeathService _deathService;
    [SerializeField] private Enemy _enemyPrefab;

    private float _minDistanceToSpawn = -4.5f;
    private float _maxDistanceToSpawn = 4.5f;

    private float _maxCountEnemys = 10f;

    private float _timeToDie = 5;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Enemy newEnemy = SpawnEnemy();
            _deathService.Register(newEnemy, () => newEnemy.IsDead == true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Enemy newEnemy = SpawnEnemy();
            SwitchColor(newEnemy, Color.blue);
            _deathService.Register(newEnemy, () => Time.time - newEnemy.SpawnTime >= _timeToDie);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Enemy newEnemy = SpawnEnemy();
            SwitchColor(newEnemy, Color.red);
            _deathService.Register(newEnemy, () => _deathService.CountEnemys() > _maxCountEnemys);
        }
    }

    private void SwitchColor(Enemy enemy, Color color)
    {
        SkinnedMeshRenderer renderer = enemy.GetComponentInChildren<SkinnedMeshRenderer>();
        renderer.material.color = color;
    }

    private Enemy SpawnEnemy()
    {
        float pointX = Random.Range(_minDistanceToSpawn, _maxDistanceToSpawn);
        float pointY = Random.Range(_minDistanceToSpawn, _maxDistanceToSpawn);
        return Instantiate(_enemyPrefab, new Vector3(pointX, 0, pointY), Quaternion.identity);
    }
}
