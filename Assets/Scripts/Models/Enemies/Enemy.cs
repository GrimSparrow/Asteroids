using System;
using UnityEngine;

namespace AsteroidsKefir.Models
{
    /// <summary>
    /// Базовый класс противников - астероиды, нло и тд.
    /// </summary>
    public abstract class Enemy : Movable, ITickable
    {
        /// <summary>
        /// Текущая скорость перемещения противника.
        /// </summary>
        protected float Velocity { get; }
        
        /// <summary>
        /// Противник убит, отправляем очки за его убийство.
        /// </summary>
        public static event Action<int> Killed;

        protected Enemy(Vector2 position, float velocity = 0f, float rotation = 0f) : base(position, rotation)
        {
            Velocity = velocity;
        }

        public abstract void Tick(float deltaTime);

        /// <summary>
        /// Убить с начислением очков.
        /// </summary>
        public void Kill()
        {
            //Просто магическое число, можно развернуть глубже, но в текущих условиях не вижу смысла.
            Killed?.Invoke(10);
            Destroy();
        }
    }
}