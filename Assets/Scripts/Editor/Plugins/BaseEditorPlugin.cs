using UnityEngine;

namespace Editting.Plugins
{
    /// <summary>
    ///     Базовый класс для плагинов
    /// </summary>
    public abstract class BaseEditorPlugin : IEditorPlugin
    {
        public EditorController BaseController { get; set; }
        public GUIContent PluginInfo { get; protected set; }

        public virtual void Init()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void UpdateGizmos()
        {
        }

        public virtual void UpdateGUI()
        {
        }

        public virtual void Destroy()
        {
        }
    }
}