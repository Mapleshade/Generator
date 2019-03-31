using System;

namespace Configurations
{
    /// <summary>
    ///     Игровые механики, которые должны присутствовать на уровне
    /// </summary>
    [Serializable]
    public class GameMechanicsOnLevel
    {
        /// <summary>
        ///     неразрушаемый объект, который игрок не может трогать
        ///     (наносится периодический урон, например, шипы)
        /// </summary>
        public bool AvoidingUnkillableObjects;

        /// <summary>
        ///     объект, несущий мгновенную смерть игроку
        ///     (например, лава)
        /// </summary>
        public bool InstantDeath;

        /// <summary>
        ///     игра не имеет конечной цели и повторяется, пока игрок не умрет
        /// </summary>
        public bool GameRepeatsUntilYouDie;

        /// <summary>
        ///     механика на тест краткоременной памяти игрока,
        ///     всё возрастающее количество объектов  
        /// </summary>
        public bool RememberAnIncreasingNumberOfThings;

        /// <summary>
        ///     игрок должен повторять серию действий 
        /// </summary>
        public bool RepeatPattern;

        /// <summary>
        ///     игрок не может оставаться на одном месте
        /// </summary>
        public bool ForcedConstantMovement;

        /// <summary>
        ///     головоломка, пазл
        /// </summary>
        public bool BlockPuzzles;

        /// <summary>
        ///     игра усложняется до тех пор, пока игрок не умрет
        /// </summary>
        public bool GameKeepsGetsHarderUntilYouDie;

        /// <summary>
        ///     несколько путей достижения конечной точки
        /// </summary>
        public bool UncountableNumberOfPossiblePaths;

        /// <summary>
        ///     игрок не сражается с врагами, а выстраивает им препятсвия на пути к цели
        /// </summary>
        public bool BlockPath;

        /// <summary>
        ///     детектив
        /// </summary>
        public bool InformationOverload;

        /// <summary>
        ///     переключение между режимами для достижения цели 
        /// </summary>
        public bool SwitchModes;

        /// <summary>
        ///     действия игрока могут приводить к появлению новых препятсвий
        /// </summary>
        public bool PushMoleDownMolePopsUp;

        /// <summary>
        ///     игрок может корректировать направление движения объекта
        /// </summary>
        public bool BouncingObject;

        /// <summary>
        ///     объекты движутся в определенном направлении
        /// </summary>
        public bool Gravity;

        /// <summary>
        ///     внимание игрока разделено между несколькими одновременными целями
        /// </summary>
        public bool SpinningPlates;

        /// <summary>
        ///     в игре присутсвуют телепорты
        /// </summary>
        public bool Teleports;

        /// <summary>
        ///     игрок управляет отрялом, а не одним персонажем
        /// </summary>
        public bool Squad;

        /// <summary>
        ///     ресурм менеджент
        /// </summary>
        public bool ScarceResource;

        /// <summary>
        ///     прыжки, игрок должен много прыгать
        /// </summary>
        public bool Jumping;

        /// <summary>
        ///     задачи, ограниченные по времени
        /// </summary>
        public bool Timed;

        /// <summary>
        ///     защита цели
        /// </summary>
        public bool ProtectTarget;

        /// <summary>
        ///     открытый мир, игрок может свободно перемещаться по локации,
        ///     возвращаться на ранее посещенные, открывать новые
        /// </summary>
        public bool UndirectedExploration;

        /// <summary>
        ///     игрок окружен большим количеством враждебных объектов
        /// </summary>
        public bool BulletHell;

        /// <summary>
        ///     торговля
        /// </summary>
        public bool BuyLowSellHigh;

        /// <summary>
        ///     файтинг, преимущественно рукопашный бой
        /// </summary>
        public bool Trading;

        /// <summary>
        ///     дальнобойная атака
        /// </summary>
        public bool Shooting;

        /// <summary>
        ///     диалоговая система
        /// </summary>
        public bool DialogueTree;

        /// <summary>
        ///     строительство
        /// </summary>
        public bool Building;

        /// <summary>
        ///     гонки
        /// </summary>
        public bool Race;
    }
}