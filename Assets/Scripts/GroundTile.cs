using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
	GroundSpawner groundSpawner;
	void Start()
	{
		groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
	}

	void OnTriggerExit(Collider other)
	{
		groundSpawner.SpawnTile();
		Destroy(gameObject, 2);
	}
}
