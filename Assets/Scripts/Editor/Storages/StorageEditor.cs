using System;
using System.IO;
using Behaviors;
using Configurations;
using UnityEditor;
using UnityEngine;
using Utils;
using Object = UnityEngine.Object;

namespace Editting.Storages
{
	public class StorageEditor : EditorWindow
	{
		[SerializeField] private static string format;
		[SerializeField] private GlobalSettings settings;
		[SerializeField] private GameBehaviour game;
		[SerializeField] private Object jsonObject;

		[MenuItem("Tools/Storage")]
		private static void Init()
		{
			var splineStorageManagerWindow = (StorageEditor) GetWindow(typeof(StorageEditor));
			splineStorageManagerWindow.position = new Rect((Screen.currentResolution.width - 600) / 2f,
				(Screen.currentResolution.height - 250) / 2f, 600, 250);
			splineStorageManagerWindow.Show();
		}

		void OnEnable()
		{
			format = ".json";
		}

		private void OnGUI()
		{
			EditorGUILayout.LabelField("GAME STORAGE MANAGER", EditorStyles.centeredGreyMiniLabel);
			EditorGUILayout.LabelField("Select game object and json file :", EditorStyles.helpBox);
			game =
				(GameBehaviour) EditorGUILayout.ObjectField("Game Behaviour", game, typeof(GameBehaviour), true);
			jsonObject =
				EditorGUILayout.ObjectField("JSON File", jsonObject, typeof(Object), true);
			EditorGUILayout.LabelField(String.Empty);
			if (GUILayout.Button("Загрузить из JSON"))
			{
				if(!IsReadyToLoadSave()) return;
				var path = AssetDatabase.GetAssetPath(jsonObject);
				LoadSplineData(path);
				game.UpdateData(settings);
			}

			if (GUILayout.Button("Сохранить в JSON"))
			{
				if (!IsReadyToLoadSave()) return;
				settings = game.GlobalSettings;
				var path = AssetDatabase.GetAssetPath(jsonObject);
				SaveSplineData(path);
			}
		}

		private bool IsReadyToLoadSave()
		{
			if (game == null)
			{
				Debug.LogError("Change GameBehaviour object!");
				return false;
			}

			if (jsonObject == null)
			{
				Debug.LogError("Change JSON file!");
				return false;
			}
			else
			{
				var path = AssetDatabase.GetAssetPath(jsonObject);
				if (!path.Contains(format))
				{
					Debug.LogError("Change JSON file! <" + jsonObject.name + "> is not json.");
					return false;
				}
			}

			return true;
		}

		private void LoadSplineData(string filePath)
		{
			if (File.Exists(filePath))
			{
				settings = JsonStorageHelper<GlobalSettings>.LoadFromFile(filePath);
				Debug.Log("Настройки загружены из <" + jsonObject.name + ">");
			}
			else
			{
				Debug.LogError("file <" + filePath + "> not found!");
			}
		}

		private void SaveSplineData(string filePath)
		{
			if (settings != null)
			{
				JsonStorageHelper<GlobalSettings>.SaveToFile(settings, filePath);
				Debug.Log("Настройки сохранены в <" + jsonObject.name + ">");
			}
			else
			{
				Debug.LogError("GameSettings is null!");
			}
		}
	}
}
