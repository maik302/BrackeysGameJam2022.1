using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
	[SerializeField] private int tracks = 5;

	// Obstacles
	[Header("Obstacles setup")]
	[SerializeField] private SpawnableObjects obstacles;

	// Coins
	[Header("Coins setup")]
	[SerializeField] private SpawnableObjects coins;

	// Cloning devices
	[Header("Cloning Arc setup")]
	[SerializeField] SpawnableObjects cloningArc;

	GroundSpawner groundSpawner;
	int maxObstacles;

    void Awake() {
		maxObstacles = obstacles.GetMaxSpawnableObjects();
		
		if (tracks - 1 < maxObstacles) {
			Debug.Log("maxObstacles must be smaller than tracks, using maximum value");
			maxObstacles = tracks - 1;
		}
	}

    void Start()
	{
		groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
		
		if (Random.value >= cloningArc.GetChanceOfSpawn()) {
			SpawnRowOfCloners();
		} else {
			SpawnSingleObjectPerTrack();
		}
	}

	void SpawnSingleObjectPerTrack() {
		int spawnedObstacles = 0;
		for (int track = 0; track < tracks; track++) {
			if (Random.value >= obstacles.GetChanceOfSpawn() && spawnedObstacles < maxObstacles) {
				spawnedObstacles++;
				SpawnGameObject(obstacles.GetObjectToSpawn(), track);
			} else if (Random.value >= coins.GetChanceOfSpawn()) {
				// Put coins where there are no obstacles
				SpawnGameObject(coins.GetObjectToSpawn(), track);
			}
		}
	}

	void SpawnRowOfCloners() {
		var activeClonerTrack = Random.Range(0, tracks);
		var activeClonerSpawnPosition = GetSpawnPosition(activeClonerTrack, tracks);

		for (int track = 0; track < tracks; track++) {
			GameObject cloner = SpawnGameObject(cloningArc.GetObjectToSpawn(), track);
			cloner.GetComponent<ClonerManager>()?.SetCloningStatus(track == activeClonerTrack);
			cloner.GetComponent<ClonerManager>()?.SetActiveClonerPosition(activeClonerSpawnPosition, gameObject.transform);
        }
    }

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			groundSpawner.SpawnTile();
			Destroy(gameObject, 2);
		}
	}

	GameObject SpawnGameObject(GameObject objectPrefab, int track)
	{
		// Spawn the object
		// Make this the parent of the object, so it gets destroyed with it
		GameObject gameObject = Instantiate(objectPrefab, transform, false);
		gameObject.transform.localPosition = GetSpawnPosition(track, tracks);

		// HACK: Fix scale of object to make it 1x1x1 again
		Vector3 objectScale = gameObject.transform.localScale;
		objectScale.x /= transform.localScale.x;
		objectScale.y /= transform.localScale.y;
		objectScale.z /= transform.localScale.z;
		gameObject.transform.localScale = objectScale;

		return gameObject;
	}

	Vector3 GetSpawnPosition(int track, int numberOfTracks) {
		// Planes have size 10
		float trackSize = 10F / (float) numberOfTracks;
		// Choose random track

		// Then, -5 is the border of a plane, and center the object in the "track"
		return new Vector3(-5F + trackSize / 2F + track * trackSize, 0F, 5F);
	}
}
