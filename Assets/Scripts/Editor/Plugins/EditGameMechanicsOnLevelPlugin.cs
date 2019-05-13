using UnityEditor;
using UnityEngine;

namespace Editting.Plugins
{
    public class EditGameMechanicsOnLevelPlugin : BaseEditorPlugin
    {
        public int selectedLevel = 0;
        public override void Init()
        {
            var icon = Resources.Load("EditGameMechanicsOnLevel_icon") as Texture;
            PluginInfo = new GUIContent(icon, "Режим редактирования игровых механик на уровне");
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

            EditorGUILayout.LabelField("Выбрать игровые механики, присутствующие на уровне", EditorStyles.boldLabel);
            var levelDataMech = BaseController.Game.GlobalSettings.levels[selectedLevel].Mechanics;

            levelDataMech.AvoidingUnkillableObjects = EditorGUILayout.Toggle(
                "неразрушаемые объекты", levelDataMech.AvoidingUnkillableObjects);

            levelDataMech.InstantDeath = EditorGUILayout.Toggle(
                "объект, несущий мгновенную смерть игроку", levelDataMech.InstantDeath);

            levelDataMech.GameRepeatsUntilYouDie = EditorGUILayout.Toggle(
                "игра не имеет конечной цели и повторяется, пока игрок не умрет", levelDataMech.GameRepeatsUntilYouDie);

            levelDataMech.RememberAnIncreasingNumberOfThings = EditorGUILayout.Toggle(
                "механика на тест краткоременной памяти игрока", levelDataMech.RememberAnIncreasingNumberOfThings);

            levelDataMech.RepeatPattern = EditorGUILayout.Toggle(
                "игрок должен повторять серию действий ", levelDataMech.RepeatPattern);

            levelDataMech.ForcedConstantMovement = EditorGUILayout.Toggle(
                "игрок не может оставаться на одном месте", levelDataMech.ForcedConstantMovement);

            levelDataMech.BlockPuzzles = EditorGUILayout.Toggle(
                "головоломка, пазл", levelDataMech.BlockPuzzles);

            levelDataMech.GameKeepsGetsHarderUntilYouDie = EditorGUILayout.Toggle(
                "игра усложняется до тех пор, пока игрок не умрет", levelDataMech.GameKeepsGetsHarderUntilYouDie);

            levelDataMech.UncountableNumberOfPossiblePaths = EditorGUILayout.Toggle(
                "несколько путей достижения конечной точки", levelDataMech.UncountableNumberOfPossiblePaths);

            levelDataMech.BlockPath = EditorGUILayout.Toggle(
                "игрок не сражается с врагами, а выстраивает им препятсвия на пути к цели", levelDataMech.BlockPath);

            levelDataMech.InformationOverload = EditorGUILayout.Toggle(
                "детектив", levelDataMech.InformationOverload);

            levelDataMech.SwitchModes = EditorGUILayout.Toggle(
                "переключение между режимами для достижения цели ", levelDataMech.SwitchModes);

            levelDataMech.PushMoleDownMolePopsUp = EditorGUILayout.Toggle(
                "действия игрока могут приводить к появлению новых препятсвий", levelDataMech.PushMoleDownMolePopsUp);

            levelDataMech.BouncingObject = EditorGUILayout.Toggle(
                "игрок может корректировать направление движения объекта", levelDataMech.BouncingObject);

            levelDataMech.Gravity = EditorGUILayout.Toggle(
                "объекты движутся в определенном направлении", levelDataMech.Gravity);

            levelDataMech.SpinningPlates = EditorGUILayout.Toggle(
                "внимание игрока разделено между несколькими одновременными целями", levelDataMech.SpinningPlates);

            levelDataMech.Teleports = EditorGUILayout.Toggle(
                "в игре присутсвуют телепорты", levelDataMech.Teleports);

            levelDataMech.Squad = EditorGUILayout.Toggle(
                "игрок управляет отрядом, а не одним персонажем", levelDataMech.Squad);

            levelDataMech.ScarceResource = EditorGUILayout.Toggle(
                "ресурс менеджент", levelDataMech.ScarceResource);

            levelDataMech.Jumping = EditorGUILayout.Toggle(
                "прыжки, игрок должен много прыгать", levelDataMech.Jumping);

            levelDataMech.Timed = EditorGUILayout.Toggle(
                "задачи, ограниченные по времени", levelDataMech.Timed);

            levelDataMech.ProtectTarget = EditorGUILayout.Toggle(
                "защита цели", levelDataMech.ProtectTarget);

            levelDataMech.UndirectedExploration = EditorGUILayout.Toggle(
                "открытый мир", levelDataMech.UndirectedExploration);

            levelDataMech.BulletHell = EditorGUILayout.Toggle(
                "игрок окружен большим количеством враждебных объектов", levelDataMech.BulletHell);

            levelDataMech.BuyLowSellHigh = EditorGUILayout.Toggle(
                "торговля", levelDataMech.BuyLowSellHigh);

            levelDataMech.Trading = EditorGUILayout.Toggle(
                "файтинг, преимущественно рукопашный бой", levelDataMech.Trading);

            levelDataMech.Shooting = EditorGUILayout.Toggle(
                "дальнобойная атака", levelDataMech.Shooting);

            levelDataMech.DialogueTree = EditorGUILayout.Toggle(
                "диалоговая система", levelDataMech.DialogueTree);

            levelDataMech.Building = EditorGUILayout.Toggle(
                "строительство", levelDataMech.Building);

            levelDataMech.Race = EditorGUILayout.Toggle(
                "гонки", levelDataMech.Race);


            EditorGUILayout.HelpBox(
                "Выберите идентификатор уровня, который должен будет сгенерирован на этой сцене и игровые механики, которые должны присутствовать",
                MessageType.Info);
        }
    }
}