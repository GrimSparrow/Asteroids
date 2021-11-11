using UnityEngine;

namespace AsteroidsKefir.Models
{
    /// <summary>
    /// Базовый класс пули.
    /// </summary>
    public abstract class Bullet : Movable, ITickable
    {
        /// <summary>
        /// Направление движения пули.
        /// </summary>
        protected Vector2 Direction;
        
        /// <summary>
        /// Текущее время жизни пули.
        /// </summary>
        private float _currentLifetime;

        protected Bullet(Vector2 position, Vector2 direction, float lifetime) : base(position, 0f)
        {
            _currentLifetime = lifetime;
            Direction = direction;
        }

        public virtual void Tick(float deltaTime)
        {
            _currentLifetime -= deltaTime;

            if (_currentLifetime <= 0) Destroy();
        }
    }
}