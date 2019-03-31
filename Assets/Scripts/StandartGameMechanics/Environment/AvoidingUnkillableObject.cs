using System.Collections;
using System.Collections.Generic;
using StandartGameMechanics.Player;
using UnityEngine;

namespace StandartGameMechanics.Environment
{
    /// <summary>
    ///     неразрушаемые объекты, наносящие периодический урон игроку при касании
    /// </summary>
    public class AvoidingUnkillableObject : MonoBehaviour
    {
        /// <summary>
        ///     наносимый урон
        /// </summary>
        [SerializeField] 
        private float damage;

        /// <summary>
        ///     время задержки
        /// </summary>
        [SerializeField] 
        private float timer;

        /// <summary>
        ///     объект находится в состоянии контакта с чем-то
        /// </summary>
        [SerializeField] 
        private bool isContacted;

        /// <summary>
        ///     состояние корутины ожидания
        /// </summary>
        [SerializeField] 
        private bool startCorutine;

        /// <summary>
        ///     Здоровье объектов, находящихся в области поражения
        /// </summary>
        private List<PlayerHealthPart> healthPart;

        private void FixedUpdate()
        {
            if (isContacted)
            {
                if (!startCorutine)
                {
                    StartCoroutine(WaitSomeTime());
                }
            }
        }

        private IEnumerator WaitSomeTime()
        {
            startCorutine = true;
            foreach (var playerHealthPart in healthPart)
            {
                playerHealthPart.TakeDamage(damage);
            }

            yield return new WaitForSeconds(timer * Time.timeScale);

            startCorutine = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (healthPart == null)
            {
                healthPart = new List<PlayerHealthPart>();
            }

            healthPart.Add(other.gameObject.GetComponent<PlayerHealthPart>());
            isContacted = true;
        }

        private void OnCollisionExit(Collision other)
        {
            var health = other.gameObject.GetComponent<PlayerHealthPart>();
            if (healthPart.Contains(health))
            {
                healthPart.Remove(health);
                isContacted = false;
            }
        }
    }
}