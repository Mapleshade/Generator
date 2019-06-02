using System.Collections.Generic;
using Configurations;
using StandartGameMechanics.Player;
using UnityEngine;

namespace Generator
{
    public class CharacterService : ICharacterService
    {
        private List<Character> characters;

        public void CreateCharacters()
        {
            for (var index = 0; index < characters.Count; index++)
            {
                var character = characters[index];
                //todo: if size 
                var gameObject = new GameObject {name = character.characterName};
                if (character.hasHealPart)
                {
                    var health = gameObject.AddComponent<PlayerHealthPart>();
                    if (character.hasExtraLives)
                    {
                        health.extraLives.ExtraLives = 3;

                    }

                }

                if (character.hasManaPart)
                {
                    gameObject.AddComponent<PlayerManaPart>();
                }

                if (character.canJump)
                {
                    gameObject.AddComponent<PlayerJump>();
                }

                if (character.isEnemyForPlayer)
                {

                }

                if (character.canBeControlByPlayer)
                {
                    gameObject.AddComponent<PlayerMovement>();

                    //todo куда ставим?
                }
            }
        }
    }
}

