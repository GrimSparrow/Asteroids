using UnityEngine;

namespace AsteroidsKefir.Models
{
    /// <summary>
    /// Луч лазера.
    /// </summary>
    public class Laser : Bullet
    {
        public Laser(Vector2 position, Vector2 direction) : base(position, direction, 0.2f)
        {
            Rotate(Vector2.SignedAngle(Vector2.up, direction));
        }
    }
}