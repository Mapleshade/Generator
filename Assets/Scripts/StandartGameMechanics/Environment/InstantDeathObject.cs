using StandartGameMechanics.Player;
using UnityEngine;

namespace StandartGameMechanics.Environment
{
    /// <summary>
    ///     шаблон объектов, вызывающих мгновенную смерть игрока
    /// </summary>
    public class InstantDeathObject : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            var health = other.gameObject.GetComponent<PlayerHealthPart>();
            if (health != null)
            {
                health.Death();
            }
        }
    }
}
