using System;
using AsteroidsKefir.Models;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Класс отвечающий за управление.
/// </summary>
public class ShipInputController
{
    private PlayerInput _input;

    /// <summary>
    /// Ссылка на модель корабля.
    /// </summary>
    private Ship _ship;
    
    /// <summary>
    /// Нажата ли кнопка движения вперед. TODO возможно пересмотрю работу в целом.
    /// </summary>
    private bool MoveForwardPerformed => _input.Ship.MoveForward.phase == InputActionPhase.Performed;

    /// <summary>
    /// Вызвана обычная атака.
    /// </summary>
    public event Action PrimaryAttackPerformed;
    
    /// <summary>
    /// Вызвана вторичная(особая) атака.
    /// </summary>
    public event Action SecondaryAttackPerformed;

    public ShipInputController(Ship ship)
    {
        _input = new PlayerInput();
        _ship = ship;
    }

    /// <summary>
    /// Включить управление.
    /// </summary>
    public void Enable()
    {
        _input.Enable();
        _input.Ship.StandartAttack.performed += PrimaryAttack;
        _input.Ship.SecondaryAttack.performed += SecondaryAttack;
    }

    /// <summary>
    /// Отключаем управление.
    /// </summary>
    public void Disable()
    {
        _input.Ship.StandartAttack.performed -= PrimaryAttack;
        _input.Ship.SecondaryAttack.performed -= SecondaryAttack;
        _input.Disable();
    }

    public void Tick()
    {
        TryMove();
        TryRotate();
    }

    /// <summary>
    /// Вызов обычной атаки.
    /// </summary>
    private void PrimaryAttack(InputAction.CallbackContext obj)
    {
        PrimaryAttackPerformed?.Invoke();
    }

    /// <summary>
    /// Вызов вторичной(особой) атаки.
    /// </summary>
    private void SecondaryAttack(InputAction.CallbackContext obj)
    {
        SecondaryAttackPerformed?.Invoke();
    }
    
    /// <summary>
    /// Вызов перемещения корабля.
    /// </summary>
    private void TryMove()
    {
        if (MoveForwardPerformed)
        {
            _ship.Accelerate(Time.deltaTime);
        }
        else
        {
            _ship.SlowDown(Time.deltaTime);
        }
    }

    /// <summary>
    /// Вызов разворота корабля.
    /// </summary>
    private void TryRotate()
    {
        var direction = _input.Ship.Rotate.ReadValue<float>();

        if (direction == 0 ) return;
        _ship.Rotate(direction, Time.deltaTime);
    }
}
