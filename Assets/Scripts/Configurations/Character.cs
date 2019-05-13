using System;

namespace Configurations
{
    [Serializable]
    public class Character
    {
        /// <summary>
        ///     юнит обладает здоровьем
        /// </summary>
        public bool hasHealPart;

        /// <summary>
        ///     юнит обладает маной
        /// </summary>
        public bool hasManaPart;

        /// <summary>
        ///     юнит может иметь дополнительные жизни
        /// </summary>
        public bool hasExtraLives;

        /// <summary>
        ///     юнит может прыгать
        /// </summary>
        public bool canJump;

        /// <summary>
        ///     юнит может быть под контролем игрока
        ///     (например, несколько юнитов в отряде)
        /// </summary>
        public bool canBeControlByPlayer;

        /// <summary>
        ///     является игроку врагом
        /// </summary>
        public bool isEnemyForPlayer;

        public int size;

        public string characterName;
    }
}