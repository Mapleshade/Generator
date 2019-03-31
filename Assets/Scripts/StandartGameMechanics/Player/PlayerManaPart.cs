using UnityEngine;

namespace StandartGameMechanics.Player
{
    /// <summary>
    ///     шаблон маны игрока
    /// </summary>
    public class PlayerManaPart : MonoBehaviour
    {
        /// <summary>
        ///     уровень маны игрока
        /// </summary>
        private float mana;

        /// <summary>
        ///     максимальный запас маны
        /// </summary>
        [Range(0, 100)]
        private float maxMana;

        /// <summary>
        ///     потратить ману
        /// </summary>
        /// <param name="value">затрачиваемое количество маны</param>
        public void SpendMana(float value)
        {
            if (mana >= value)
            {
                mana -= value;
            }
        }
        
        /// <summary>
        ///     восстановить ману
        /// </summary>
        /// <param name="value">количество восстанавливаемого здоровья</param>
        public void RestoreHealth(float value)
        {
            mana += value;
            if (mana > maxMana)
            {
                mana = maxMana;
            }
        }

        private void Update()
        {
            if (mana < maxMana)
            {
                mana += Time.deltaTime;
            }
            
            if (mana > maxMana)
            {
                mana = maxMana;
            }
        }

        private void Start()
        {
            if (maxMana <= 0)
            {
                maxMana = 100f;
            }
        }
    }
}
