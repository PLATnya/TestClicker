using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnPool : MonoBehaviour
{
    public GameObject PrefabToSpawn;
    private GameObject[] _pooledArray;
    [SerializeField]
    private int _maxCapacity = 10;

    private int _lastIndex = 0;

    void Awake()
    {
        _pooledArray = new GameObject[_maxCapacity];
    }

    public GameObject Spawn()
    {
        if (_lastIndex < _maxCapacity - 1)
        {
            GameObject newObject = Instantiate(PrefabToSpawn);
            _pooledArray[_lastIndex] = newObject;
            ++_lastIndex;
            return newObject;
        }
        else
        {
            GameObject spawningObject = _pooledArray[0];
            for (int i = 0; i < _pooledArray.Length; ++i)
            {
                if (_pooledArray[i]&&!_pooledArray[i].activeInHierarchy)
                {
                    spawningObject = _pooledArray[i];
                    break;
                }
            }

            spawningObject.SetActive(true);
            return spawningObject;
        }
    }
} 
