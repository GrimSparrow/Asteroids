using System;
using UnityEngine;

namespace AsteroidsKefir.Models
{
    /// <summary>
    /// Базовый класс перемещаемых объектов.
    /// </summary>
    public abstract class Movable
    {
        /// <summary>
        /// Максимальный угол поворота.
        /// </summary>
        private const float MAX_ROTATION_ANGLE = 360f;
        
        /// <summary>
        /// Текущая позиция в пространстве.
        /// </summary>
        public Vector2 Position { get; private set; }
        
        /// <summary>
        /// Текущий угол поворота.
        /// </summary>
        public float Rotation { get; private set; }

        /// <summary>
        /// Текущий Forward вектор объекта.
        /// </summary>
        public Vector2 Forward => Quaternion.Euler(0f, 0f, Rotation) * Vector3.up;

        /// <summary>
        /// Изменилось текущее положение объекта в пространстве.
        /// </summary>
        public event Action<Vector2> PositionChanged;

        /// <summary>
        /// Изменился угол поворота объекта;
        /// </summary>
        public event Action<float> RotationChanged;

        /// <summary>
        /// Начался процесс удаления объекта.
        /// </summary>
        public event Action Destroying;
        
        /// <summary>
        /// Конструктор типа.
        /// </summary>
        /// <param name="position">Исходная позиция.</param>
        /// <param name="rotation">Исходный угол поворота.</param>
        protected Movable(Vector2 position, float rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        /// <summary>
        /// Мгновенно переместить объект в позицию.
        /// </summary>
        /// <param name="position">Новая позиция в пространстве.</param>
        protected void MoveToPosition(Vector2 position)
        {
            Position = position;
            PositionChanged?.Invoke(Position);
        }

        protected void Rotate(float angle)
        {
            Rotation = Mathf.Repeat(Rotation + angle, MAX_ROTATION_ANGLE);
            RotationChanged?.Invoke(Rotation);
        }

        protected void Destroy()
        {
            Destroying?.Invoke();
        }
    }
}