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
    
    
    void Start()
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
            for (int i = 0; i < _pooledArray.Length; ++i)
            {
                if (!_pooledArray[i].activeInHierarchy) return _pooledArray[i];
            }

            return _pooledArray[0];
        }
    }
    void Update()
    {
        
    }
}
