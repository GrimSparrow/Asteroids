using AsteroidsKefir.Models;
using Config;
using UnityEngine;

/// <summary>
/// Простой спавнер противников, теоретически можно было бы накрутить еще пул чтобы не генерить постоянно, так было бы
/// правильно.
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    /// <summary>
    /// Основной управляющий компонент.
    /// </summary>
    [SerializeField] private Application application;
    
    /// <summary>
    /// Время ожидания до спавна следующего противника.
    /// </summary>
    private float _waitToSpawnPeriod;
    
    /// <summary>
    /// Генератор представлений.
    /// </summary>
    [SerializeField] private ViewsSpawner viewsSpawner;
    
    void Update()
    {
        if (_waitToSpawnPeriod <= 0)
        {
            SpawnEnemy();
            _waitToSpawnPeriod = Random.Range(Configuration.MinSpawnTime, Configuration.MaxSpawnTime);
        }
        else
        {
            _waitToSpawnPeriod -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Создать противника.
    /// </summary>
    private void SpawnEnemy()
    {
        var spawnProbability = Random.value;
        var startPosition = Random.insideUnitCircle.normalized + new Vector2(0.5F, 0.5F);
        var velocity = Random.Range(Configuration.MinEnemyVelocity, Configuration.MaxEnemyVelocity);
        
        if (spawnProbability >= Configuration.UfoSpawnProbability)
        {
            var direction = (new Vector2(Random.value, Random.value) - startPosition).normalized;
            var asteroidModel = new Asteroid(startPosition, direction, velocity);
            viewsSpawner.GenerateAsteroidView(asteroidModel);
        }
        else
        {
            var ufoModel = new Ufo(startPosition, application.ShipModel, velocity);
            viewsSpawner.GenerateUfo(ufoModel);
        }
    }
}
