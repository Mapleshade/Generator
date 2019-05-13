using System;
using System.Collections.Generic;

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
        public List<Character> Characters = new List<Character>();
    }
}
