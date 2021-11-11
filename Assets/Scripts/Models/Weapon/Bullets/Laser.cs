namespace AsteroidsKefir.Models
{
    /// <summary>
    /// Луч лазера.
    /// </summary>
    public class Laser : Bullet
    {
        /// <summary>
        /// Владелец лазера.
        /// </summary>
        private readonly Movable _owner;
        
        public Laser(Movable owner) : base(owner.Position, owner.Forward, 0.1f)
        {
            _owner = owner;
        }

        public override void Tick(float deltaTime)
        {
            Rotate(_owner.Rotation - Rotation);
            MoveToPosition(_owner.Position);
            
            base.Tick(deltaTime);
        }
    }
}