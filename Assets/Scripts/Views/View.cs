using System;
using AsteroidsKefir.Models;
using UnityEngine;

/// <summary>
/// Базовый класс представления.
/// </summary>
public class View : MonoBehaviour
{
    /// <summary>
    /// Модель движимого объекта.
    /// </summary>
    private Movable _movableModel;
    
    /// <summary>
    /// Основная камера на сцене, нужна для преобразования координат представления.
    /// </summary>
    private Camera _camera;

    /// <summary>
    /// Ссылка на "обновляемый" объект.
    /// </summary>
    private ITickable _tickable;

    private Vector3 ModelPosition => new Vector3(_movableModel.Position.x, _movableModel.Position.y, 1);

    /// <summary>
    /// Инициализировать представление и связать с моделью.
    /// </summary>
    /// <param name="model"></param>
    public void Initialize(Movable model, Camera camera)
    {
        _movableModel = model;
        _camera = camera;

        var tickable = model as ITickable;
        _tickable = tickable;
        
        OnPositionChanged(Vector2.zero);
        OnRotationChanged(0f);
        enabled = true;
    }

    private void OnEnable()
    {
        _movableModel.PositionChanged += OnPositionChanged;
        _movableModel.RotationChanged += OnRotationChanged;
        _movableModel.Destroying += OnDestroy;
    }

    private void Update() => _tickable?.Tick(Time.deltaTime);

    private void OnDisable()
    {
        _movableModel.PositionChanged -= OnPositionChanged;
        _movableModel.RotationChanged -= OnRotationChanged;
        _movableModel.Destroying -= OnDestroy;
    }

    /// <summary>
    /// Изменилось положение модели в пространстве.
    /// </summary>
    /// <param name="position"></param>
    private void OnPositionChanged(Vector2 position) => transform.position = _camera.ViewportToWorldPoint(ModelPosition);

    /// <summary>
    /// Изменился угол поворота модели.
    /// </summary>
    /// <param name="angle"></param>
    private void OnRotationChanged(float angle) => transform.rotation = Quaternion.Euler(0f, 0f, _movableModel.Rotation);

    /// <summary>
    /// Уничтожить объект.
    /// </summary>
    private void OnDestroy() => Destroy(gameObject);
}
