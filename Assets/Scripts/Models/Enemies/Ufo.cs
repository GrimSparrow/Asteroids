using UnityEngine;

namespace AsteroidsKefir.Models
{
    /// <summary>
    /// Противник - НЛО. Приследует корабль игрока.
    /// </summary>
    public class Ufo : Enemy
    {
        /// <summary>
        /// Текущая приследуемая цель НЛО.
        /// </summary>
        private readonly Movable _currentTarget;
        
        public Ufo(Vector2 position, Movable target, float velocity = 0.05f) : base(position, velocity)
        {
            _currentTarget = target;
        }

        public override void Tick(float deltaTime)
        {
            var newPosition = Vector2.MoveTowards(Position, _currentTarget.Position, Velocity * deltaTime);
            MoveToPosition(newPosition);
        }
    }
}