using System;
using UnityEngine;

namespace AsteroidsKefir.Models
{
    /// <summary>
    /// Корабль, по сути игрок.
    /// </summary>
    public class Ship : Movable, ITickable
    {
        public Ship(Vector2 position, float rotation) : base(position, rotation)
        {
            BaseWeapon = new Weapon(this);
            BlasterWeapon = new Blaster(this, 10, 5f);
        }

        /// <summary>
        /// Максимальное ускорение корабля.
        /// </summary>
        private const float maxAcceleration = 0.002f;

        /// <summary>
        /// Значение перемещения за фрейм.
        /// </summary>
        private const float unitsPerFrame = 0.001f;

        /// <summary>
        /// Основное оружие.
        /// </summary>
        public Weapon BaseWeapon { get; }
        
        /// <summary>
        /// Дополнительное оружие.
        /// </summary>
        public Blaster BlasterWeapon { get; }
        
        /// <summary>
        /// Текущее ускорение корабля.
        /// </summary>
        private Vector2 _currentAcceleration;

        /// <summary>
        /// Изменилось ускорение.
        /// </summary>
        public event Action<float> AccelerationChanged;

        /// <summary>
        /// Придать кораблю ускорение.
        /// </summary>
        /// <param name="deltaTime">Время прошедшее с прошлого тика.</param>
        public void Accelerate(float deltaTime)
        {
            _currentAcceleration += Forward * deltaTime * unitsPerFrame;
            _currentAcceleration = Vector2.ClampMagnitude(_currentAcceleration, maxAcceleration);
            AccelerationChanged?.Invoke(_currentAcceleration.magnitude);
        }

        /// <summary>
        /// Замедлить.
        /// </summary>
        /// <param name="deltaTime">Время прошедшее с прошлого тика.</param>
        public void SlowDown(float deltaTime)
        {
            _currentAcceleration -= _currentAcceleration * deltaTime;
            AccelerationChanged?.Invoke(_currentAcceleration.magnitude);
        }

        /// <summary>
        /// Повенуть корабль.
        /// </summary>
        /// <param name="direction">Направление поворота.</param>
        /// <param name="deltaTime">Время прошедшее с прошлого тика.</param>
        public void Rotate(float direction, float deltaTime)
        {
            direction = direction > 0 ? 1 : -1;
            var rotationAngle = direction * deltaTime * 180f;
            Rotate(rotationAngle);
        }

        public void Tick(float deltaTime)
        {
            BaseWeapon.Update(deltaTime);
            BlasterWeapon.Update(deltaTime);
            
            var newPosition = Position + _currentAcceleration;
            newPosition.x = Mathf.Repeat(newPosition.x, 1);
            newPosition.y = Mathf.Repeat(newPosition.y, 1);

            MoveToPosition(newPosition);
        }
    }
}