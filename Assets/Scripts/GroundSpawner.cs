using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour {
    public static GroundSpawner Instance;

    [SerializeField] private GameObject _groundTilePrefab;
    [SerializeField] private GameObject _cloneTilePrefab;
    Vector3 nextSpawnPoint = Vector3.zero;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        }
    }

    public void SpawnTile()
    {
        var prefab = _groundTilePrefab;
        if (Random.value <= 0.4) {
            prefab = _cloneTilePrefab;
        }
        GameObject spawned = Instantiate(prefab, nextSpawnPoint, Quaternion.identity, transform);
        nextSpawnPoint = spawned.transform.Find("Next Tile").transform.position;
    }

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnTile();
        }
    }

}
