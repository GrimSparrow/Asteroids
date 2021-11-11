using AsteroidsKefir.Models;
using UnityEngine;

/// <summary>
/// Главный компоненте, управляющий игрой.
/// </summary>
public class Application : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    
    /// <summary>
    /// Представление корабля.
    /// </summary>
    [SerializeField] private ShipView shipView;
    
    /// <summary>
    /// Генератор представлений.
    /// </summary>
    [SerializeField] private ViewsSpawner viewsSpawner;

    /// <summary>
    /// Окно результата. Можно инстансить, но сейчас просто включаю.
    /// </summary>
    [SerializeField] private EndGameView endGameView;

    /// <summary>
    /// Контроллер инпута.
    /// </summary>
    private ShipInputController _shipInputController;
    
    /// <summary>
    /// Модель корабля.
    /// </summary>
    private Ship _shipModel;

    /// <summary>
    /// Модель корабля.
    /// </summary>
    public Ship ShipModel => _shipModel;

    private void Awake()
    {
        var shipStartPosition = new Vector2(0.5f, 0.5f);
        _shipModel = new Ship(shipStartPosition, 0f);
        shipView.Initialize(_shipModel, mainCamera);
        
        _shipInputController = new ShipInputController(_shipModel);
    }
    
    private void OnEnable()
    {
        _shipInputController.Enable();
        _shipModel.BaseWeapon.Shooting += OnShot;
        _shipModel.BlasterWeapon.Shooting += OnShot;
        _shipModel.Destroying += OnPlayerDie;
    }

    private void Update()
    {
        _shipInputController.Tick();
    }

    private void OnDisable()
    {
        _shipInputController.Disable();
        _shipModel.BaseWeapon.Shooting -= OnShot;
        _shipModel.BlasterWeapon.Shooting -= OnShot;
        _shipModel.Destroying += OnPlayerDie;
    }

    /// <summary>
    /// Был произведен выстрел.
    /// </summary>
    private void OnShot(Bullet bullet)
    {
        viewsSpawner.GenerateBulletView(bullet);
    }

    /// <summary>
    /// Действия при поражении игрока.
    /// </summary>
    private void OnPlayerDie()
    {
        Time.timeScale = 0;
        _shipInputController.Disable();
        endGameView.ShowEndView();
    }
}
