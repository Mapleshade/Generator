using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnvironment : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;
    
    [SerializeField]
    private GameObject danger;

    public void Generate()
    {
        var dangerSockets = GameObject.FindGameObjectsWithTag("Danger");
        var platformSockets = GameObject.FindGameObjectsWithTag("Platform");

        foreach (var dangerSocket in dangerSockets)
        {
            if (Random.Range(0, 2) == 1)
            {
                var dangerObject = Instantiate(danger);
                dangerObject.transform.position = dangerSocket.transform.position;
            }
        }
        
        foreach (var platformSocket in platformSockets)
        {
            if (Random.Range(0, 2) == 1)
            {
                var platformObject = Instantiate(platform);
                platformObject.transform.position = platformSocket.transform.position;
            }
        }
    }
}
