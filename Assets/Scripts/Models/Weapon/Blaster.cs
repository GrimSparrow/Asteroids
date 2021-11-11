using System;

namespace AsteroidsKefir.Models
{
    /// <summary>
    /// Пушка, стреляющая лазером.
    /// </summary>
    public class Blaster : Weapon
    {
        /// <summary>
        /// Максимальное число пуль в обойме.
        /// </summary>
        private readonly int _maxBulletsInClip;
        
        /// <summary>
        /// Время перезарядки.
        /// </summary>
        private readonly float _reloadTime;

        /// <summary>
        /// Текущий прогресс перезарядки.
        /// </summary>
        public float CurrentReloadTime { get; private set; }

        /// <summary>
        /// Число пуль в обойме в текущий момент.
        /// </summary>
        public int CurrentBulletsInClip { get; private set; }

        /// <summary>
        /// Изменилось число пуль.
        /// </summary>
        public event Action<int> BulletCountChanged;

        /// <summary>
        /// Изменилось время перезарядки.
        /// </summary>
        public event Action<float> ReloadTimeChanged;

        /// <summary>
        /// Возможен ли выстрел в текущий момент.
        /// </summary>
        protected override bool CanShoot => base.CanShoot && CurrentBulletsInClip > 0;

        public Blaster(Movable owner, int bulletsInClip, float reloadTime) : base(owner)
        {
            _maxBulletsInClip = bulletsInClip;
            CurrentBulletsInClip = bulletsInClip;
            _reloadTime = reloadTime;
            CurrentReloadTime = reloadTime;
        }

        /// <summary>
        /// Произвести выстрел.
        /// </summary>
        public override void Shoot()
        {
            if (!CanShoot) return;
            
            CurrentBulletsInClip--;
            BulletCountChanged?.Invoke(CurrentBulletsInClip);
            base.Shoot();
        }

        /// <summary>
        /// Обновление.
        /// </summary>
        /// <param name="deltaTime">Время прошедшее с прошлого тика.</param>
        public override void Update(float deltaTime)
        {
            if (CurrentBulletsInClip > 0) return;
            
            CurrentReloadTime -= deltaTime;
            ReloadTimeChanged?.Invoke(CurrentReloadTime);
            
            if (CurrentReloadTime <= 0)
            {
                CurrentReloadTime = _reloadTime;
                CurrentBulletsInClip = _maxBulletsInClip;
                BulletCountChanged?.Invoke(CurrentBulletsInClip);
            }
        }

        /// <summary>
        /// Создать пулю.
        /// </summary>
        protected override Bullet AddBullet() => new Laser(ShotStart);
    }
}