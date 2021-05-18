using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private UISpawnerManager _uiSpawnerManager;
    [SerializeField]
    private SpawnPool _spawnPool;

    private float Speed
    {
        get => Speed;
        set
        {
            Speed = value;
            _uiSpawnerManager.SetSpeed(value);
        }
    }

    private float Distance{
        get => Distance;
        set
        {
            if (value < 0) Distance = 0;
            else Distance = value;
            _uiSpawnerManager.SetDistance(value);
        }
        
    }

    private float SpawnDelay
    {
        get => SpawnDelay;
        set
        {
            if (SpawnDelay < 0) SpawnDelay = 0;
            else SpawnDelay = value;
            _uiSpawnerManager.SetSpawnDelay(value);
        }
    }

    [SerializeField] private Transform _spawnPoint;

    private Vector3 _destinationPoint;
    void Start()
    {
        _destinationPoint = _spawnPoint.position + transform.forward * Distance;
        StartCoroutine(SpawnCubes());
    }

    IEnumerator MoveCube(Transform cubeTransform)
    {
        float t = 0;
        Vector3 startPosition = cubeTransform.position;
        while (t < 1)
        {
            cubeTransform.position = Vector3.Lerp(startPosition, _destinationPoint, t);
            t += Time.deltaTime * Speed;
            yield return null;
        }
        cubeTransform.gameObject.SetActive(false);
    }
    
    IEnumerator SpawnCubes()
    {
        while (true)
        {
            Transform spawnedCubeTransform = _spawnPool.Spawn().transform;
            spawnedCubeTransform.position = _spawnPoint.position;
            StartCoroutine(MoveCube(spawnedCubeTransform));
            yield return new WaitForSeconds(SpawnDelay);
        }
    }
}
