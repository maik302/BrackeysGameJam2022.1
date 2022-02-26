using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour {
	public static GroundSpawner Instance;

	[SerializeField] private GameObject _groundTilePrefab;
	Vector3 nextSpawnPoint = Vector3.zero;

    void Awake() {
		if (Instance == null) {
			Instance = this;
        }
    }

    public void SpawnTile()
	{
		GameObject spawned = Instantiate(_groundTilePrefab, nextSpawnPoint, Quaternion.identity, transform);
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
