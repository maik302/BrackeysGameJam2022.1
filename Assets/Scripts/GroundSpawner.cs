using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
	public GameObject groundTilePrefab;
	Vector3 nextSpawnPoint = Vector3.zero;

	public void SpawnTile()
	{
		GameObject spawned = Instantiate(groundTilePrefab, nextSpawnPoint, Quaternion.identity, transform);
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
