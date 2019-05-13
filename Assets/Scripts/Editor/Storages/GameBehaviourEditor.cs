using Behaviors;
using Editting.Storages;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Editting
{
    [CustomEditor(typeof(GameBehaviour))]
    public class GameBehaviourEditor : Editor
    {
        private readonly UnityEvent onGraphChanged = new UnityEvent();
        private GameBehaviour gameBehaviour;

        public void OnEnable()
        {
            Tools.hidden = true;
            onGraphChanged.AddListener(Repaint);
            onGraphChanged.AddListener(SceneView.RepaintAll);
            if (gameBehaviour == null)
                gameBehaviour = target as GameBehaviour;
        }

        public void OnDisable()
        {
            Tools.hidden = false;
            onGraphChanged.RemoveAllListeners();
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            gameBehaviour = target as GameBehaviour;
            if (gameBehaviour == null)
                return;
            EditorGUILayout.LabelField("GameSettings", EditorStyles.boldLabel);
            EditorGUILayout.Space();
            if (GUILayout.Button("Загрузить из JSON | Сохранить в JSON"))
            {
                var editorWindow = EditorWindow.GetWindow(typeof(StorageEditor));
                editorWindow.position = new Rect((Screen.currentResolution.width - 600) / 2f,
                    (Screen.currentResolution.height - 250) / 2f, 600, 250);
                editorWindow.Show();
            }
        }

    }
}
