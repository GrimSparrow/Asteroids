using AsteroidsKefir.Models;
using UnityEngine;
using Views.Weapons;

namespace Views.Enemies
{
    /// <summary>
    /// Представление противника.
    /// </summary>
    public class EnemyView : View
    {
        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out BulletView bullet))
            {
                KillEnemy();
            }
        }

        /// <summary>
        /// Убить противника и начислить очки.
        /// </summary>
        protected void KillEnemy()
        {
            var enemyModel = Model as Enemy;
            enemyModel.Kill();
        }
    }
}
