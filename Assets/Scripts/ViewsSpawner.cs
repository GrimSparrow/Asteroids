using AsteroidsKefir.Models;
using UnityEngine;
using Views.Enemies;

/// <summary>
/// Своеобразный генератор представлений.
/// </summary>
public class ViewsSpawner : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    /// <summary>
    /// Префаб астероида.
    /// </summary>
    [SerializeField] private View asteroidPrefab;
    
    /// <summary>
    /// Префаб частей астероида.
    /// </summary>
    [SerializeField] private View asteroidPartPrefab;
    
    /// <summary>
    /// Префаб летающей тарелки.
    /// </summary>
    [SerializeField] private View ufoPrefab;
    
    /// <summary>
    /// Префаб обычной пули.
    /// </summary>
    [SerializeField] private View bulletPrefab;
    
    /// <summary>
    /// Префаб лазера.
    /// </summary>
    [SerializeField] private View laserPrefab;

    /// <summary>
    /// Сгенерировать представление.
    /// </summary>
    /// <param name="blueprint">Чертеж, по которому создается представление.</param>
    /// <param name="model">Модель данных для представления.</param>
    private View GenerateView(View blueprint, Movable model)
    {
        var view = Instantiate(blueprint);
        view.Initialize(model, _camera);

        return view;
    }
    
    /// <summary>
    /// Сгенерировать представление астероида.
    /// </summary>
    /// <param name="asteroid">Модель данных астероида.</param>
    public void GenerateAsteroidView(Asteroid asteroid)
    {
        var asteroidView = GenerateView(asteroidPrefab, asteroid) as AsteroidView;
        asteroidView.Destroying += GenerateAsteroidParts;
    }

    /// <summary>
    /// Сгенерировать части астероида при его разрушении. В данном случае просто 3 части разлетается.
    /// </summary>
    /// <param name="model">Модель данных разрушенного астероида.</param>
    private void GenerateAsteroidParts(Movable model)
    {
        for (var i = 0; i < 3; i++)
        {
            var asteroidModel = new Asteroid(model.Position, Random.insideUnitCircle.normalized);
            GenerateView(asteroidPartPrefab, asteroidModel);
        }
    }

    /// <summary>
    /// Сгенерировать представление пули.
    /// </summary>
    /// <param name="bullet">Модель пули.</param>
    public void GenerateBulletView(Bullet bullet)
    {
        GenerateView(bullet is Laser ? laserPrefab : bulletPrefab, bullet);
    }

    /// <summary>
    /// Сгенерировать нло.
    /// </summary>
    /// <param name="ufo">Модель нло.</param>
    public void GenerateUfo(Ufo ufo)
    {
        GenerateView(ufoPrefab, ufo);
    }
}
