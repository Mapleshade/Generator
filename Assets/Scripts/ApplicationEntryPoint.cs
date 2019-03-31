using Configurations;
using UnityEngine;
using System.IO;

public class ApplicationEntryPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start() //тестовый прогон 
    {
        var settings = new GlobalSettings();
        
        settings.levels = new LevelConfiguration[2];

        settings.levels[0] = new LevelConfiguration
        {
            Mechanics = new GameMechanicsOnLevel(), Views = new CameraOnLevel {TypeOfView = new int[1]}
        };
        settings.levels[0].Views.TypeOfView[0] = 1;

        settings.levels[1] = new LevelConfiguration
        {
            Mechanics = new GameMechanicsOnLevel(), Views = new CameraOnLevel {TypeOfView = new int[1]}
        };
        settings.levels[1].Views.TypeOfView[0] = 1;
        

        var json = JsonUtility.ToJson(settings, true);
        File.WriteAllText(Application.streamingAssetsPath + "\\Settings.json", json);
    }

    
}
