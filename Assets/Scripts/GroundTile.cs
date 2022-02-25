using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
	[SerializeField] private double tracks = 5;

	[SerializeField] private List<GameObject> obstaclePrefabs;
	[SerializeField] private double maxObstacles;
	[SerializeField] private double chanceOfObstacle = 0.5;
	[SerializeField] private List<GameObject> coinPrefabs;
	[SerializeField] private double chanceOfCoin = 0.5;

	GroundSpawner groundSpawner;

	void Start()
	{
		groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();

		if (tracks - 1 < maxObstacles) {
			Debug.Log("maxObstacles must be smaller than tracks, using maximum value");
			maxObstacles = tracks - 1;
		}
		int spawnedObstacles = 0;
		for (int track = 0; track < tracks; track++)
		{
			if (Random.value >= chanceOfObstacle && spawnedObstacles <= maxObstacles)
			{
				spawnedObstacles++;
				SpawnGameObject(getRandomPrefab(obstaclePrefabs), track);
			}
			else if (Random.value >= chanceOfCoin)
			{
				// Put coins where there are no obstacles
				SpawnGameObject(getRandomPrefab(coinPrefabs), track);
			}
		}
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			groundSpawner.SpawnTile();
			Destroy(gameObject, 2);
		}
	}

	void SpawnGameObject(GameObject objectPrefab, int track)
	{
		// Planes have size 10
		float trackSize = 10F / (float)tracks;
		// Choose random track

		// Then, -5 is the border of a plane, and center the object in the "track"
		Vector3 spawnPosition = new Vector3(-5F + trackSize / 2F + track * trackSize, 0F, 5F);

		// Spawn the object
		// Make this the parent of the object, so it gets destroyed with it
		GameObject gameObject = Instantiate(objectPrefab, transform, false);
		gameObject.transform.localPosition = spawnPosition;

		// HACK: Fix scale of object to make it 1x1x1 again
		Vector3 objectScale = gameObject.transform.localScale;
		objectScale.x /= transform.localScale.x;
		objectScale.y /= transform.localScale.y;
		objectScale.z /= transform.localScale.z;
		gameObject.transform.localScale = objectScale;
	}

	private GameObject getRandomPrefab(List<GameObject> prefabs) {
		return prefabs[Random.Range(0, prefabs.Count)];
	}
}
