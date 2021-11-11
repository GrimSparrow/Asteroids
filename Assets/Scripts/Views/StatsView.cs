using TMPro;
using UnityEngine;

/// <summary>
/// Панель отображения различных игровых статистик.
/// </summary>
public class StatsView : MonoBehaviour
{
    /// <summary>
    /// Ссылка на главный компонент.
    /// </summary>
    [SerializeField] private Application app;
    
    /// <summary>
    /// Поле отображения координат корабля.
    /// </summary>
    [SerializeField] private TextMeshProUGUI coordinatesField;
    
    /// <summary>
    /// Поле отображения угла поворота корабля.
    /// </summary>
    [SerializeField] private TextMeshProUGUI angleField;
    
    /// <summary>
    /// Поле отображения скорости корабля.
    /// </summary>
    [SerializeField] private TextMeshProUGUI velocityField;
    
    /// <summary>
    /// Поле отображения числа оставшихся пуль у лазерной пушки корабля.
    /// </summary>
    [SerializeField] private TextMeshProUGUI bulletsField;
    
    /// <summary>
    /// Поле отображения времени до полной зарядки корабля.
    /// </summary>
    [SerializeField] private TextMeshProUGUI reloadTimeField;
    
    private void OnEnable()
    {
        app.ShipModel.PositionChanged += OnCoordinatesChanged;
        app.ShipModel.RotationChanged += OnRotationChanged;
        app.ShipModel.AccelerationChanged += OnVelocityChanged;
        app.ShipModel.BlasterWeapon.BulletCountChanged += OnLaserBulletsCountChanged;
        app.ShipModel.BlasterWeapon.ReloadTimeChanged += OnLaserReloadingTimeChanged;
        
        OnLaserBulletsCountChanged(app.ShipModel.BlasterWeapon.CurrentBulletsInClip);
        OnLaserReloadingTimeChanged(0);
    }

    private void OnDisable()
    {
        app.ShipModel.PositionChanged -= OnCoordinatesChanged;
        app.ShipModel.RotationChanged -= OnRotationChanged;
        app.ShipModel.AccelerationChanged -= OnVelocityChanged;
        app.ShipModel.BlasterWeapon.BulletCountChanged -= OnLaserBulletsCountChanged;
        app.ShipModel.BlasterWeapon.ReloadTimeChanged -= OnLaserReloadingTimeChanged;
    }

    /// <summary>
    /// Изменились координаты корабля.
    /// </summary>
    private void OnCoordinatesChanged(Vector2 coordinates)
    {
        coordinatesField.SetText($"Координаты корабля: {coordinates}");
    }

    /// <summary>
    /// Изменился угол поворота корабля.
    /// </summary>
    private void OnRotationChanged(float angle)
    {
        angleField.SetText($"Угол поворота: {angle}");
    }

    /// <summary>
    /// Изменилась скорость корабля.
    /// </summary>
    private void OnVelocityChanged(float velocity)
    {
        velocityField.SetText($"Скорость: {velocity * 1000 : 0.0}");
    }
    
    /// <summary>
    /// Изменилось число доступных пуль лазера.
    /// </summary>
    private void OnLaserBulletsCountChanged(int bulletCount)
    {
        bulletsField.SetText($"Число лазеров: {bulletCount}");
    }
    
    /// <summary>
    /// Изменилось время перезарядки лазерной пущки.
    /// </summary>
    private void OnLaserReloadingTimeChanged(float time)
    {
        reloadTimeField.SetText($"Время перезарядки: {time :0.0}");
    }
}
