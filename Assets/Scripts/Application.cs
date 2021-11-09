using AsteroidsKefir.Models;
using UnityEngine;
using Views;

public class Application : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private ShipView shipView;
    [SerializeField] private StandartBulletView bulletPrefab;
    [SerializeField] private LaserBulletView laserPrefab;

    private ShipInputController _shipInputController;
    
    /// <summary>
    /// Модель корабля.
    /// </summary>
    private Ship _shipModel;

    private void Awake()
    {
        _shipModel = new Ship(new Vector2(0.5f, 0.5f), 0f);
        _shipInputController = new ShipInputController(_shipModel);
        shipView.Initialize(_shipModel, camera);
    }

    private void OnEnable()
    {
        _shipInputController.Enable();
        
        //Вероятно надо будет делать фабрику и не забыть отписаться. Пока так в тестовых целях.
        _shipInputController.PrimaryAttackPerformed += () =>
        {
            var bulletView = Instantiate(bulletPrefab);
            var bullet = new StandartBullet(_shipModel.Position, _shipModel.Forward);
            bulletView.Initialize(bullet, camera);
        };
        
        _shipInputController.SecondaryAttackPerformed += () =>
        {
            var bulletView = Instantiate(laserPrefab);
            var bullet = new Laser(_shipModel.Position, _shipModel.Forward);
            bulletView.Initialize(bullet, camera);
        };
    }

    private void Update()
    {
        _shipInputController.Tick();
    }

    private void OnDisable()
    {
        _shipInputController.Disable();
    }
}
