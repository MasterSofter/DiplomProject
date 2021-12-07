using System;
using System.Collections.Generic;
using UnityEngine;

namespace DynamicSystems
{
    /// <summary>
    /// Система событий, посредством которой общаются DynamicPlayerControllSystem
    /// и DynamicAnimationsSystem, ничего при этом друг о друге не зная
    /// </summary>
    public class EventsSystem
    {
        /// <summary>
        /// Событие ходьбы: 
        /// [1-ый параметр: двумерный вектор направления движения]
        /// [2-ой параметр: массив из двух строк (имена параметров анимации): первая строка - движение по оси X,
        /// вторая строка - движение по оси Z]
        /// [3-й параметр: ссылка на корневой игровой объект, который движется]
        /// [4-й параметр: ссылка на Transform камеры]
        /// </summary>
        public Action<Vector2, string[], GameObject, GameObject> MoveEvent;

        /// <summary>
        /// Событие начала бега, которое является триггером
        /// </summary>
        public Action StartRunEvent;

        /// <summary>
        /// Событие конца бега, которе является триггером
        /// </summary>
        public Action FinishRunEvent;

        /// <summary>
        /// Событие обнаружения препятствия
        /// [1-ый параметр GameObject - ссылка на обнаруженное препятствие
        /// 2-ой параметр GameObject - ссылка на игрока]
        /// </summary>
        public Action<GameObject, GameObject> ObstacleDetectedEvent;

        /// <summary>
        /// Событие обнаружения препятствия
        /// [1-ый параметр GameObject - ссылка на обнаруженное препятствие
        /// 2-ой параметр GameObject - ссылка на игрока]
        /// </summary>
        public Action<GameObject, GameObject> ObstacleMissedEvent;


        /// <summary>
        /// Событие нажатия кнопки прыжка
        /// [1-ый параметр GameObject - ссылка на игрока]
        /// </summary>
        public Action<GameObject> ButtonJumpPressedEvent;

        /// <summary>
        /// События отжатия кнопик прыжка
        /// </summary>
        public Action ButtonJumpReleaseEvent;

        /// <summary>
        /// Событие обнаружения области для лазания
        /// [1-ый параметр GameObject - ссылка на препятствие поле для лазания
        /// 2-ой параметр GameObject - ссылка на игрока]
        /// </summary>
        public Action<GameObject, GameObject> ClimbAreaDetectedEvent;

        /// <summary>
        /// Событие потери из видимости области для лазания
        /// [1-ый параметр GameObject - ссылка на препятствие поле для лазания
        /// 2-ой параметр GameObject - ссылка на игрока]
        /// </summary>
        public Action<GameObject, GameObject> ClimbAreaMissedEvent;


        public Action StartClimbingUpWallEvent;
        public Action FinishClimbingUpWallEvent;

        public Action TopClimbWallDetectedEvent;



        /**************************************************************
         *                  События для проигрывания анимаций
         * ***********************************************************/

        public Action<Vector2, string[]> Animation_MoveEvent;
        public Action Animation_StartClimbingUpWallEvent;
        public Action Animation_FinishClimbimgUpWallEvent;
        public Action Animation_StartRunEvent;
        public Action Animation_FinishRunEvent;
        public Action Animation_JumpOverObstacleEvent;
        public Action Animation_VaultOverObstacleEvent;

    }

}

