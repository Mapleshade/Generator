using System.Collections;
using UnityEngine;

namespace StandartGameMechanics.Environment
{
    /// <summary>
    ///     объект, перемещающийся между
    ///     двумя координатами с определенной периодичностью
    /// </summary>
    public class MovingObject : MonoBehaviour
    {
        /// <summary>
        ///     начальное положение
        /// </summary>
        [SerializeField] 
        private Vector3 startPos;

        /// <summary>
        ///     конечное положение
        /// </summary>
        [SerializeField] 
        private Vector3 endPos;

        /// <summary>
        ///     скорость перемещения
        /// </summary>
        [SerializeField] 
        private float speed;

        /// <summary>
        ///     время остановки
        /// </summary>
        [SerializeField] 
        private float timer;

        /// <summary>
        ///     направление
        /// </summary>
        [SerializeField] 
        private bool direction;

        /// <summary>
        ///     состояние корутины ожидания
        /// </summary>
        [SerializeField] 
        private bool startCorutine;

        private void FixedUpdate()
        {
            var step = speed * Time.deltaTime;

            if (direction)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos, step);
                if ((transform.position - endPos).magnitude < 0.5f && !startCorutine)
                {
                    StartCoroutine(WaitSomeTime());
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, step);
                if ((transform.position - startPos).magnitude < 0.5f && !startCorutine)
                {
                    StartCoroutine(WaitSomeTime());
                }
            }
        }

        private IEnumerator WaitSomeTime()
        {
            startCorutine = true;

            yield return new WaitForSeconds(timer * Time.timeScale);
            direction = !direction;


            startCorutine = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            other.transform.parent = transform;
        }

        private void OnCollisionExit(Collision other)
        {
            other.transform.parent = null;
        }
    }
}