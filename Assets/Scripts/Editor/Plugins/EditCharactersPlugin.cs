using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Editting.Plugins
{
    public class EditCharactersPlugin : BaseEditorPlugin
    {
        public int selectedLevel = 0;
        public override void Init()
        {
            var icon = Resources.Load("EditCharactersOnLevel_icon") as Texture;
            PluginInfo = new GUIContent(icon, "Режим редактирования персонажей на уровне");
        }

        public override void UpdateGUI()
        {
            if (BaseController.ViewModel.SelectedPlugin != this)
            {
                return;
            }

            selectedLevel = EditorGUILayout.IntField("Редактируемый уровень", selectedLevel);
            if (selectedLevel >= BaseController.Game.GlobalSettings.levels.Length)
            {
                selectedLevel = BaseController.Game.GlobalSettings.levels.Length - 1;
            }

            EditorGUILayout.LabelField("Редактирование персонажей, присутствующих на уровне", EditorStyles.boldLabel);
            
            var characters = BaseController.Game.GlobalSettings.levels[selectedLevel].Characters;

            foreach (var character in characters)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                character.characterName = EditorGUILayout.TextField("Персонаж ", character.characterName); 
                character.hasHealPart = EditorGUILayout.Toggle("Обладает здоровьем", character.hasHealPart);
                character.hasManaPart = EditorGUILayout.Toggle("Обладает запасом маны", character.hasManaPart);
                character.hasExtraLives = EditorGUILayout.Toggle("Обладает доп. жизнями", character.hasExtraLives);
                character.canJump = EditorGUILayout.Toggle("Может прыгать", character.canJump);
                character.canBeControlByPlayer = EditorGUILayout.Toggle("Может быть управляем игроком", character.canBeControlByPlayer);
                character.size = EditorGUILayout.IntField("Размер персонажа", character.size);                
                character.isEnemyForPlayer = EditorGUILayout.Toggle("Враждебен к игроку", character.isEnemyForPlayer);

                EditorGUILayout.EndVertical();
            }
        }

    }
}

