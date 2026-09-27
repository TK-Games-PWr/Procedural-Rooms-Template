using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class SpawnManager : MonoBehaviour
{
    [Tooltip("Rooms that can be spawned")]
    [SerializeField] List<GameObject> spawnableRooms;
    [Tooltip("Points where rooms can be spawned")]
    [SerializeField] List<Transform> spawnPoints;
    [Tooltip("Number of rooms to be spawned")]
    [SerializeField] int numberOfRooms;

    private List <Transform> _freeSpawnPoints;
    void Start()
    {
        if (numberOfRooms > spawnPoints.Count)
        {
            throw new Exception("There are more rooms to spawn than possible spawnPoints");
        }
        
        _freeSpawnPoints = new List<Transform>(spawnPoints);
        for(int i = 0; i < numberOfRooms; i++)
        {
            SpawnRoon();
        }
    }
    void SpawnRoon()
    {
        if (_freeSpawnPoints.Count == 0) return;
        int i = Random.Range(0, _freeSpawnPoints.Count);
        Transform spawnPoint = _freeSpawnPoints[i];
        _freeSpawnPoints[i] = _freeSpawnPoints[^1];
        _freeSpawnPoints.RemoveAt(_freeSpawnPoints.Count - 1);
        
        int j = Random.Range(0, spawnableRooms.Count);
        Instantiate(spawnableRooms[j], spawnPoint.position, Quaternion.identity);
    }
}
