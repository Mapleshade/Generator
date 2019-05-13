using System;
using System.Collections.Generic;
using Behaviors;
using Configurations;
using Editting.Plugins;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Editting
{
    public class EditorController : EditorWindow
    {
        /// <summary>
        ///     Плагины которые будут использованы в работе редактора
        /// </summary>
        public IList<IEditorPlugin> Plugins { get; set; }

        public EditorViewTools View;
        public EditorViewModel ViewModel;
        public GameBehaviour Game;


        private string viewModelKey =>
            EditorSceneManager.GetActiveScene().name + " $ " + nameof(EditorController);

        [MenuItem("Tools/Редактор уровня")]
        static void Init()
        {
            EditorController window =
                (EditorController) EditorWindow.GetWindow(typeof(EditorController), false,
                    "Редактор уровня", true);
            window.Show();
        }

        private void EditorUpdate()
        {
            foreach (var plugin in Plugins)
            {
                plugin.UpdateGizmos();
            }
        }

        private void OnDisable()
        {
            SceneView.onSceneGUIDelegate -= OnSceneGUI;
            EditorPrefs.SetString(viewModelKey, JsonUtility.ToJson(ViewModel));
        }
        
        private void OnSceneGUI(SceneView sceneView)
        {
            if (Game == null)
            {
                return;
            }
            
            foreach (var editorPlugin in Plugins)
            {
                editorPlugin.Update();
            }
        }

        private void OnGUI()
        {
            View.DrawBefore();

            foreach (var plugin in Plugins)
            {
                plugin.UpdateGUI();
            }

            View.DrawAfter();
        }

        private void OnEnable()
        {
            Game = FindObjectOfType<GameBehaviour>();
            try
            {
                ViewModel = EditorPrefs.HasKey(viewModelKey)
                    ? JsonUtility.FromJson<EditorViewModel>(EditorPrefs.GetString(viewModelKey))
                    : new EditorViewModel();
            }
            catch (Exception e)
            {
                ViewModel = new EditorViewModel();
                Debug.LogException(e);
            }


            Plugins = new List<IEditorPlugin>().AddFromAppDomain();
            View = new EditorViewTools(ViewModel, this, Plugins);
            View.OnSelectPlugin += ViewOnSelectPlugin;
            foreach (var plugin in Plugins)
            {
                plugin.BaseController = this;
                plugin.Init();
            }
        }

        private void ViewOnSelectPlugin(IEditorPlugin obj)
        {
            ViewModel.SelectedPlugin = obj;
            //  ViewModel.Mode = GraphToolMode.Plugin;
        }
    }
}