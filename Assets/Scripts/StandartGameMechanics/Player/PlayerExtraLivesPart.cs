namespace StandartGameMechanics.Player
{
    public class PlayerExtraLivesPart : IPlayerExtraLivesPart
    {
        public int ExtraLives { get; set; }
        
        public void AddExtraLives(int value)
        {
            ExtraLives += value;
        }
        
    }
}
