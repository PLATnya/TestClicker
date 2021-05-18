using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private UISpawnerManager _uiSpawnerManager;
    [SerializeField]
    private SpawnPool _spawnPool;

    [SerializeField]
    private float _speed =1;

    [SerializeField]
    private float _distance = 20;

    [SerializeField]
    private float _spawnDelay = 0.5f;

    [SerializeField] private Transform _spawnPoint;

    private Vector3 _destinationPoint;
    void Start()
    {
        StartCoroutine(SpawnCubes());
        _uiSpawnerManager.SetSpeed(_speed);
        _uiSpawnerManager.SetDistance(_distance);
        _uiSpawnerManager.SetSpawnDelay(_spawnDelay);
    }

    IEnumerator MoveCube(Transform cubeTransform)
    {
        float t = 0;
        Vector3 startPosition = cubeTransform.position;
        while (t < 1)
        {
            cubeTransform.position = Vector3.LerpUnclamped(startPosition, _destinationPoint, t);
            t += Time.deltaTime * _speed;
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
            yield return new WaitForSeconds(_spawnDelay);
        }
    }



    public void SetSpeedFromUserInput(String input)
    {
        float newSpeed;
        if (float.TryParse(input, out newSpeed)) _speed = newSpeed;
        _uiSpawnerManager.SetSpeed(_speed);
    }
    public void SetDistanceFromUserInput(String input)
    {
        float newDistance;
        if (float.TryParse(input, out newDistance)&& newDistance>0) _distance= newDistance;
        _uiSpawnerManager.SetDistance(_distance);
        _destinationPoint = _spawnPoint.position + transform.forward * _distance;
    }
    
    public void SetSpawnDelayFromUserInput(String input)
    {

        float newSpawnDelay;
        if (float.TryParse(input, out newSpawnDelay) && newSpawnDelay > 0)
        {
            _spawnDelay= newSpawnDelay;
            StopAllCoroutines();
            StartCoroutine(SpawnCubes());
            _spawnPool.UnspawnAll();
        }
        _uiSpawnerManager.SetSpawnDelay(_spawnDelay);
    }
}
