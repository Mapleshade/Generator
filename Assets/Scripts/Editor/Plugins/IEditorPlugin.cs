using UnityEngine;

namespace Editting.Plugins
{
    /// <summary>
    ///     Плагин для редактора уровня
    /// </summary>
    public interface IEditorPlugin
    {
        /// <summary>
        ///     Ссылка на контроллер в который добавлен плагин
        /// </summary>
        EditorController BaseController { get; set; }

        /// <summary>
        ///     Информация о плагине
        /// </summary>
        GUIContent PluginInfo { get; }

        /// <summary>
        ///     Происходит при инициализации плагина
        /// </summary>
        void Init();

        /// <summary>
        ///     Обновление логики(почти как MonoBehaviour.Update)
        /// </summary>
        void Update();

        /// <summary>
        ///     Обновление в сцене для использования Gizmos
        /// </summary>
        void UpdateGizmos();

        /// <summary>
        ///     Обновление панелей в GUI редактора
        /// </summary>
        void UpdateGUI();

        /// <summary>
        ///     При закрытии редактора 
        /// </summary>
        void Destroy();
    }
}