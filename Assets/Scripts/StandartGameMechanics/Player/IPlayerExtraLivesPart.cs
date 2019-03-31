namespace StandartGameMechanics.Player
{
    /// <summary>
    ///     шаблон дополнительных жизней игрока
    /// </summary>
    public interface IPlayerExtraLivesPart 
    {
        /// <summary>
        ///     количество дополнительных жизней игрока
        /// </summary>
        int ExtraLives { get; set; }

        /// <summary>
        ///     добавить дополнительные жизни
        /// </summary>
        /// <param name="value"></param>
        void AddExtraLives(int value);
    }
}
