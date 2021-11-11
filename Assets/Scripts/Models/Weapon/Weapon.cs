using System;

namespace AsteroidsKefir.Models
{
    /// <summary>
    /// Базовый класс оружия.
    /// </summary>
    public class Weapon
    {
        /// <summary>
        /// Точка из которой будет воспроизводиться выстрел.
        /// </summary>
        protected readonly Movable ShotStart;
        
        /// <summary>
        /// Произведен выстрел.
        /// </summary>
        public event Action<Bullet> Shooting;
        
        /// <summary>
        /// Возможен ли выстрел в текущий момент.
        /// </summary>
        protected virtual bool CanShoot => true;

        public Weapon(Movable owner)
        {
            ShotStart = owner;
        }

        /// <summary>
        /// Произвести выстрел.
        /// </summary>
        public virtual void Shoot()
        {
            var bullet = AddBullet();
            Shooting?.Invoke(bullet);
        }

        /// <summary>
        /// Обновление.
        /// </summary>
        /// <param name="deltaTime">Время прошедшее с прошлого тика.</param>
        public virtual void Update(float deltaTime) { }
        
        /// <summary>
        /// Создать пулю.
        /// </summary>
        protected virtual Bullet AddBullet() => new StandartBullet(ShotStart.Position, ShotStart.Forward);
    }
}