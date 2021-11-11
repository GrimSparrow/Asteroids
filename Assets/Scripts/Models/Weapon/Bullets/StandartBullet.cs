using UnityEngine;

namespace AsteroidsKefir.Models
{
    /// <summary>
    /// Обычная пуля.
    /// </summary>
    public class StandartBullet : Bullet
    {
        /// <summary>
        /// Скорость перемещения.
        /// </summary>
        private float _velocity;

        public StandartBullet(Vector2 position, Vector2 direction, float velocity = 1f, float lifetime = 3f) : base(
            position, direction, lifetime)
        {
            _velocity = velocity;
        }

        public override void Tick(float deltaTime)
        {
            var newPosition = Position + Direction * _velocity * deltaTime;
            MoveToPosition(newPosition);
            base.Tick(deltaTime);
        }
    }
}