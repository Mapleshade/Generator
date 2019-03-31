using UnityEngine;

namespace StandartGameMechanics.Player
{
    /// <summary>
    ///     шаблон прыжков игрока
    /// </summary>
    public class PlayerJump : MonoBehaviour
    {
        /// <summary>
        ///     сколько прыжков может совершить игрок
        /// </summary>
        [SerializeField] 
        private int countOfJumMax;

        /// <summary>
        ///     Сколько прыжков сделал игрок
        /// </summary>
        [SerializeField] 
        private int countOfJump;

        /// <summary>
        ///     нажата ли клавиша прыжка
        /// </summary>
        [SerializeField] 
        private bool isPressedJump;

        /// <summary>
        ///     сила прыжка
        /// </summary>
        private float forceForJump;

        /// <summary>
        ///     Rigidbody объекта
        /// </summary>
        private Rigidbody rigidbody;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            if (forceForJump <= 0)
            {
                forceForJump = 6f;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && countOfJumMax > countOfJump && !isPressedJump)
            {
                isPressedJump = true;
                Jump();
            }
        }
        private void Jump()
        {
            countOfJump++;
            rigidbody.AddForce(transform.up * forceForJump, ForceMode.Impulse);
        }
    }
}
