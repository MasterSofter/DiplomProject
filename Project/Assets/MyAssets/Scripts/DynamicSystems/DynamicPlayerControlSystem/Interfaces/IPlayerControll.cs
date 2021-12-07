using UnityEngine;

namespace DynamicSystems.Interfaces
{
    public interface IPlayerControll
    {
        public Quaternion Evaluate(Vector2 vector2, Transform transform, GameObject gameObj);
    }
}

