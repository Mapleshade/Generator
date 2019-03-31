using UnityEngine;
using Zenject;

namespace StandartGameMechanics.Player
{
    /// <summary>
    ///     шаблон здоровья игрока
    /// </summary>
    public class PlayerHealthPart : MonoBehaviour
    {
        /// <summary>
        ///     уровень здоровья игрока
        /// </summary>
        private float health;
        
        /// <summary>
        ///     максимальный запас здоровья
        /// </summary>
        [Range(0, 100)]
        private float maxHealth;

        /// <summary>
        ///     дополнительные жизни игрока (опционально)
        /// </summary>
        [Inject] 
        private PlayerExtraLivesPart extraLives;

        /// <summary>
        ///     получить урон
        /// </summary>
        /// <param name="damage">наносимый игроку урон</param>
        public void TakeDamage(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Death();
            }
        }

        /// <summary>
        ///     восстановить здоровье
        /// </summary>
        /// <param name="value">количество восстанавливаемого здоровья</param>
        public void RestoreHealth(float value)
        {
            health += value;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }

        /// <summary>
        ///     гибель персонажа
        /// </summary>
        public void Death()
        {
            if (extraLives != null)
            {
                extraLives.ExtraLives--;
            }
            //todo: логика при гибели персонажа чем определяется?
        }
    }
}
