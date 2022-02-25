using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
	[SerializeField] private List<GameObject> obstaclePrefabs;
	[SerializeField] private double chanceOfObstacle = 0.5;
	[SerializeField] private double tracks = 5;

	GroundSpawner groundSpawner;

	void Start()
	{
		groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();

		for (int i = 0; i < tracks; i++)
		{
			SpawnObstacle(i);
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

	void SpawnObstacle(int obstacleTrack)
	{
		if (Random.value >= chanceOfObstacle)
		{
			return;
		}

		// Planes have size 10
		float trackSize = 10F / (float)tracks;
		// Choose random track

		// Then, -5 is the border of a plane, and center the obstacle in the "track"
		Vector3 spawnPosition = new Vector3(-5F + trackSize / 2F + obstacleTrack * trackSize, 0F, 5F);

		// Spawn the obstacle
		// Make this the parent of the obstacle, so it gets destroyed with it
		GameObject obstacle = Instantiate(getRandomObstaclePrefab(), transform, false);
		obstacle.transform.localPosition = spawnPosition;

		// HACK: Fix scale of obstacle to make it 1x1x1 again
		Vector3 obstacleScale = obstacle.transform.localScale;
		obstacleScale.x /= transform.localScale.x;
		obstacleScale.y /= transform.localScale.y;
		obstacleScale.z /= transform.localScale.z;
		obstacle.transform.localScale = obstacleScale;
	}

	private GameObject getRandomObstaclePrefab() {
		return obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];
    }
}
