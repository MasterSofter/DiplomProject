using UnityEngine;

namespace DynamicSystems.Interfaces
{
    public interface IPlayerControll
    {
        /// <summary>
        /// Расчитывает логику движения и поворота игрока
        /// Получает на входе Transform обьекта камеры
        /// </summary>
        /// <returns>
        /// Кватернион ориентации игрока
        /// </returns>
        public Quaternion Evaluate(Vector2 directionMoveInputXZ, Transform playerTransform, GameObject camera);
    }
}

