using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnableObjects {

    [SerializeField] private List<GameObject> _objectsToSpawn;
    [SerializeField] private double _chanceOfSpawn;
    [SerializeField] private int _maxSpawnableObjects;

    public GameObject GetObjectToSpawn() {
        return (_objectsToSpawn.Count == 1) ? _objectsToSpawn[0] : _objectsToSpawn[Random.Range(0, _objectsToSpawn.Count)];
    }

    public double GetChanceOfSpawn() {
        return _chanceOfSpawn;
    }

    public int GetMaxSpawnableObjects() {
        return _maxSpawnableObjects;
    }
}
