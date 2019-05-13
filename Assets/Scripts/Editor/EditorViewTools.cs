using System;
using System.Collections.Generic;
using System.Linq;
using Editting.Plugins;
using UnityEditor;
using UnityEngine;

namespace Editting
{
    public class EditorViewTools 
    {
        // Start is called before the first frame update
        /// <summary>
        ///     Высота ячейки кнопки с темплейтом
        /// </summary>
        public const float CELL_HEIGHT = 64;
        
        /// <summary>
        ///     Ширина ячейки кнопки с темплейтом
        /// </summary>
        public const float CELL_WIDTN = 64;
        
        /// <summary>
        ///     Ширина кнопки тулбара
        /// </summary>
        public const float TOOL_BUTTON_WIDTH = 26;
        
        /// <summary>
        ///     Высота кнопки тулбара
        /// </summary>
        public const float TOOL_BUTTON_HEIGHT = 24;

        public Vector2 GlobalScroll;
        public Vector2 TemplatesScroll;
        public Vector2 PartGraphScroll;
        
        public EditorViewModel ViewModel;
        public EditorWindow Window;
        
        private readonly IList<IEditorPlugin> Plugins;
        public event Action<IEditorPlugin> OnSelectPlugin; 
        
        public EditorViewTools(EditorViewModel viewModel, EditorWindow window, IList<IEditorPlugin> plugins) 
        {
            ViewModel = viewModel;
            Window = window;
            Plugins = plugins;
        }
        public void DrawBefore()
        {
            EditorGUIUtility.labelWidth = 400;
            EditorGUILayout.LabelField("РЕДАКТОР УРОВНЯ", EditorStyles.centeredGreyMiniLabel);
            
            DrawModeToolbox();
            
            GlobalScroll = EditorGUILayout.BeginScrollView(GlobalScroll);
        }

        public void DrawAfter()
        {
            GUILayout.FlexibleSpace();
            
            DrawGeneratePanel();
            
            EditorGUILayout.EndScrollView();
        }
        
        private void DrawPluginToolBox()
        {
            var selected = ViewModel.SelectedPlugin == null ? -1 : Plugins.IndexOf(ViewModel.SelectedPlugin);
            
            var pluginContents = Plugins.Select(p => p.PluginInfo.image).ToArray();
            var mode = GUILayout.Toolbar(selected, pluginContents,
                GUILayout.Width(TOOL_BUTTON_WIDTH * pluginContents.Length),
                GUILayout.Height(TOOL_BUTTON_HEIGHT));

            if (mode != selected)
            {
                OnSelectPlugin?.Invoke(Plugins[mode]);
            }
        }
        
        private void DrawModeToolbox()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space();
            
            DrawPluginToolBox();
            
            EditorGUILayout.Space();
            EditorGUILayout.EndHorizontal();
            
            
            GUILayout.Space(5);

            
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space();
            
            EditorGUILayout.Space();
            EditorGUILayout.EndHorizontal();
            
            GUILayout.Space(5);
        }
        
        
        private void DrawGeneratePanel()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.BeginHorizontal();
            
            if (GUILayout.Button("СГЕНЕРИРОВАТЬ УРОВЕНЬ"))
            {
               // OnValidateClick?.Invoke();
            }
            
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.EndVertical();
        }
    }
}
