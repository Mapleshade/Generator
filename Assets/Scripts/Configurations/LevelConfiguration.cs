using System;

namespace Configurations
{
    /// <summary>
    ///     конфигурация уровня
    /// </summary>
    [Serializable]
    public class LevelConfiguration
    {
        public GameMechanicsOnLevel Mechanics;
        public CameraOnLevel Views;
    }
}
