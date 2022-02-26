using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : BaseTile {

	// Obstacles
	[Header("Obstacles setup")]
	[SerializeField] private SpawnableObjects obstacles;

	// Coins
	[Header("Coins setup")]
	[SerializeField] private SpawnableObjects coins;

	int maxObstacles;

    void Awake() {
		maxObstacles = obstacles.GetMaxSpawnableObjects();
		
		if (_tracks - 1 < maxObstacles) {
			Debug.Log("maxObstacles must be smaller than tracks, using maximum value");
			maxObstacles = _tracks - 1;
		}
	}

    void Start() {
		SpawnSingleObjectPerTrack();
	}

	void SpawnSingleObjectPerTrack() {
		int spawnedObstacles = 0;
		for (int track = 0; track < _tracks; track++) {
			if (Random.value >= obstacles.GetChanceOfSpawn() && spawnedObstacles < maxObstacles) {
				spawnedObstacles++;
				SpawnGameObject(obstacles.GetObjectToSpawn(), track, _tracks);
			} else if (Random.value >= coins.GetChanceOfSpawn()) {
				// Put coins where there are no obstacles
				SpawnGameObject(coins.GetObjectToSpawn(), track, _tracks);
			}
		}
	}
}
