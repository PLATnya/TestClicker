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
    [SerializeField] private Transform _spawnPoint;

    private Vector3 _destinationPoint;
    void Start()
    {
        _destinationPoint = _spawnPoint.position + transform.forward * _distance;
        StartCoroutine(SpawnCubes());
    }

    IEnumerator MoveCube(Transform cubeTransform)
    {
        float t = 0;
        Vector3 startPosition = cubeTransform.position;
        while (t < 1)
        {
            cubeTransform.position = Vector3.Lerp(startPosition, _destinationPoint, t);
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
}
