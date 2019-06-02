﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Behaviors;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private bool[,] roomsState = new bool[4,4];

    [SerializeField]
    private GameObject room_1;
    
    [SerializeField]
    private GameObject room_2;
    
    [SerializeField]
    private GameObject room_3;
    
    [SerializeField]
    private GameObject room_4;
    
    [SerializeField]
    private GameObject room_5;
    
    [SerializeField]
    private GameObject room_6;

    [SerializeField]
    private float roomLengt = 25;

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        for (var index0 = 0; index0 < roomsState.GetLength(0); index0++)
        for (var index1 = 0; index1 < roomsState.GetLength(1); index1++)
        {
            roomsState[index0, index1] = Random.Range(0, 2) == 1;
        }
        
        for (var index0 = 0; index0 < roomsState.GetLength(0); index0++)
        for (var index1 = 0; index1 < roomsState.GetLength(1); index1++)
        {
            if (roomsState[index0, index1])
            {
                 var prefab = FindPrefab(index0, index1);
                var room = Instantiate(prefab);
                room.transform.position = new Vector3(index0 * roomLengt, 0, index1 * roomLengt);
                
            }
        }
    }

    private GameObject FindPrefab(int index0, int index1)
    {
        var doors = new bool[4];

        //верхняя грань
        if (index0 == 0)
        {
            doors[0] = false;
        }
        else
        {
            doors[0] = roomsState[index0 - 1, index1];
        }
        
        //нижняя грань
        if (index0 == roomsState.GetLength(0) - 1)
        {
            doors[1] = false;
        }
        else
        {
            doors[1] = roomsState[index0 + 1, index1];
        }
        
        //правая грань
        if (index1 == roomsState.GetLength(1) - 1)
        {
            doors[2] = false;
        }
        else
        {
            doors[2] = roomsState[index0, index1 + 1];
        }
        
        //левая грань
        if (index1 == 0)
        {
            doors[3] = false;
        }
        else
        {
            doors[3] = roomsState[index0, index1 - 1];
        }
        
        var count = doors.Count(door => door);
        
        //выбор префаба
        switch (count)
        {
            case 1:
                return room_2;
            case 2:
            {
                return doors[0] && doors[2] || doors[1] && doors[3] ? room_3 : room_4;
            }
            case 3:
                return room_5;
            case 4:
                return room_6;
            default:
                return room_1;
        }
    }
}
