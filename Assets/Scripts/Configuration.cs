namespace Config
{
    /// <summary>
    /// Простейшая конфигурация игры. Можно в целом сделать через SO. Но в данном случае нет особого
    /// смысла заморачиваться.
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Минимальное время до спавна следующего противника.
        /// </summary>
        public static readonly float MinSpawnTime = 1f;
        
        /// <summary>
        /// Максимальное время до спавна следующего противника.
        /// </summary>
        public static readonly float MaxSpawnTime = 2f;
        
        /// <summary>
        /// Минимальная скорость передвижения противника.
        /// </summary>
        public static readonly float MinEnemyVelocity = 0.04f;
        
        /// <summary>
        /// Максимальная скорость передвижения противника.
        /// </summary>
        public static readonly float MaxEnemyVelocity = 0.12f;

        /// <summary>
        /// Вероятность появления НЛО.
        /// </summary>
        public static readonly float UfoSpawnProbability = 0.3f;
    }
}