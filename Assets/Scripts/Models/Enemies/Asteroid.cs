using UnityEngine;

namespace AsteroidsKefir.Models
{
    /// <summary>
    /// Модель астероида. Также используется для частей на которые разваливается астероид т.к. по сути разницы между
    /// ними нет.
    /// </summary>
    public class Asteroid : Enemy
    {
        /// <summary>
        /// Расстояние от центра за пределами которого астероид будет уничтожаться в целях оптимизации.
        /// Очень простое решение.
        /// </summary>
        private const float DESTROY_DISTANCE = 1.7f;
        
        /// <summary>
        /// Направление движения.
        /// </summary>
        private readonly Vector2 _direction;

        public Asteroid(Vector2 position, Vector2 direction, float velocity = 0.05f) : base(position, velocity)
        {
            _direction = direction;
        }

        public override void Tick(float deltaTime)
        {
            MoveToPosition(Position + Velocity * _direction * deltaTime);
            if (Vector2.Distance(Position, Vector2.zero) > DESTROY_DISTANCE)
            {
                Destroy();
            }
        }
    }
}