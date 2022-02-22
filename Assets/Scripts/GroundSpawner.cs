using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
	public GameObject groundTile;
	Vector3 nextSpawnPoint;

	public void SpawnTile()
	{
		GameObject spawned = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
		nextSpawnPoint = spawned.transform.GetChild(1).transform.position;
	}

	void Start()
	{
		for (int i = 0; i < 20; i++)
		{
			SpawnTile();
		}
	}

}
