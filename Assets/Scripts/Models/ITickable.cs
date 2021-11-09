namespace AsteroidsKefir.Models
{
    /// <summary>
    /// Предоставляет функционал обновления каждый кадр.
    /// </summary>
    public interface ITickable
    {
        /// <summary>
        /// Произвести обновление.
        /// </summary>
        /// <param name="deltaTime">Время прошедшее с прошлого тика.</param>
        public void Tick(float deltaTime);
    }
}