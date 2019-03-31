using System;

namespace Configurations
{
    /// <summary>
    ///     расстановка камер на уровне
    /// </summary>
    [Serializable]
    public class CameraOnLevel
    {
        /// <summary>
        ///     можно ли переключаться между режимами игроку
        /// </summary>
        public bool CanSwitchView;

        /// <summary>
        ///     доступные виды камер на уровне, где номер - это идентификатор режима
        /// </summary>
        public int[] TypeOfView;
    }

//    public enum TypeOfView //todo: решить вопрос с идентификацией режимов камер
//    {
//        FirstPersonView,
//        ThirdPersonView,
//        IsometryTopView,
//        IsometrySideView,
//        FreeCamera
//    }
}
