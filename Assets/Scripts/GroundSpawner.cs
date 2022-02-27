using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour {
    public static GroundSpawner Instance;

	[Header("Ground tiles")]
	[SerializeField] private GameObject _groundTilePrefab;
	[SerializeField] private int _minGroundTiles;
	[SerializeField] private int _maxGroundTiles;

	[Header("Cloning tiles")]
	[SerializeField] private GameObject _cloningTilePrefab;

	Vector3 _nextSpawnPoint = Vector3.zero;

	int _nextNumberOfGroundTilesToSpawn;
	int _spawnedGroundTiles;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        }

		ResetGroundTilesToSpawn();
    }

	void ResetGroundTilesToSpawn() {
		_nextNumberOfGroundTilesToSpawn = Random.Range(_minGroundTiles, _maxGroundTiles);
		_spawnedGroundTiles = 0;
	}

    public void SpawnTile() {
		if (_spawnedGroundTiles <= _nextNumberOfGroundTilesToSpawn) {
			SpawnGroundTile();
        } else {
			ResetGroundTilesToSpawn();
			SpawnCloningTile();
        }
	}

	GameObject SpawnGroundTile() {
		GameObject spawned = Instantiate(_groundTilePrefab, _nextSpawnPoint, Quaternion.identity, transform);
		_nextSpawnPoint = spawned.transform.Find("Next Tile").transform.position;
		_spawnedGroundTiles++;
		return spawned;
	}

	GameObject SpawnCloningTile() {
		GameObject spawned = Instantiate(_cloningTilePrefab, _nextSpawnPoint, Quaternion.identity, transform);
		_nextSpawnPoint = spawned.transform.Find("Next Tile").transform.position;
		return spawned;
	}

	void Start() {
		for (int i = 0; i < 10; i++)
		{
			SpawnTile();
		}
	}

}
