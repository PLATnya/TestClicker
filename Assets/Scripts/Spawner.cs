using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private SpawnPool _spawnPool;
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;
    [SerializeField] private float _spawnDelay;

    void Start()
    {
        
    }

    IEnumerator SpawnCubes()
    {
        while (true)
        {
            _spawnPool.Spawn();
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
