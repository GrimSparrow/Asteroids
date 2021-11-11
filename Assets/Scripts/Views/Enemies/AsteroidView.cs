using System;
using AsteroidsKefir.Models;
using UnityEngine;
using Views.Weapons;

namespace Views.Enemies
{
    /// <summary>
    /// Представление астероида.
    /// </summary>
    public class AsteroidView : EnemyView
    {
        /// <summary>
        /// Произошло разрушение астероида из-за попадания пули.
        /// </summary>
        public event Action<Movable> Destroying;

        protected override void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out BulletView bullet))
            {
                Destroying?.Invoke(Model);
                KillEnemy();
            }
        }
    }
}
