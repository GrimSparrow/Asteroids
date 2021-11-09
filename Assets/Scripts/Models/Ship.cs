using UnityEngine;

namespace AsteroidsKefir.Models
{
    public class Ship : Movable, ITickable
    {
        public Ship(Vector2 position, float rotation) : base(position, rotation) { }

        /// <summary>
        /// Максимальное ускорение корабля.
        /// </summary>
        private const float MAX_ACCELERATION = 0.0015f;
        
        /// <summary>
        /// Текущее ускорение корабля.
        /// </summary>
        private Vector2 _currentAcceleration;

        /// <summary>
        /// Придать кораблю ускорение.
        /// </summary>
        /// <param name="deltaTime">Время прошедшее с прошлого тика.</param>
        public void Accelerate(float deltaTime)
        {
            _currentAcceleration += Forward * deltaTime * 0.001f;
            _currentAcceleration = Vector2.ClampMagnitude(_currentAcceleration, MAX_ACCELERATION);
        }

        /// <summary>
        /// Замедлить.
        /// </summary>
        /// <param name="deltaTime">Время прошедшее с прошлого тика.</param>
        public void SlowDown(float deltaTime)
        {
            _currentAcceleration -= _currentAcceleration * deltaTime;
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
            var newPosition = Position + _currentAcceleration;
            newPosition.x = Mathf.Repeat(newPosition.x, 1);
            newPosition.y = Mathf.Repeat(newPosition.y, 1);

            MoveToPosition(newPosition);
        }
    }
}