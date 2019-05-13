using Editting.Plugins;
using UnityEngine;

namespace Editting
{
    public class EditorViewModel 
    {
        /// <summary>
        ///     Выделеный плагин
        /// </summary>
        public IEditorPlugin SelectedPlugin { get; set; }
    }
}
