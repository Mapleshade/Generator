using UnityEngine;

namespace StandartGameMechanics.Player
{
    /// <summary>
    ///     шаблон перемещения игрока при фиксированной скорости перемещения
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] 
        [Range(0, 10)]
        private float speed;

        private void Start()
        {
            if (speed <= 0)
            {
                speed = 4f;
            }
        }

        private void FixedUpdate()
        {
            //движение вперед
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * speed / 2 * Time.deltaTime;
            }

            //движение назад 
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.forward * speed / 4 * Time.deltaTime;
            }

            //движение влево
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                transform.Rotate(Vector3.down);
            }

            //движение вправо
            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                transform.Rotate(-Vector3.down);
            }
        }
    }
}