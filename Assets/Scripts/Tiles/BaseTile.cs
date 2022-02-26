using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTile : MonoBehaviour {

    [SerializeField] protected int _tracks = 5;

    void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Player")) {
            GroundSpawner.Instance.SpawnTile();
            Destroy(gameObject, 2);
        }
    }

    protected GameObject SpawnGameObject(GameObject objectPrefab, int track, int numberOfTracks) {
        // Spawn the object
        // Make this the parent of the object, so it gets destroyed with it
        GameObject gameObject = Instantiate(objectPrefab, transform, false);
        gameObject.transform.localPosition = GetSpawnPosition(track, numberOfTracks);

        // HACK: Fix scale of object to make it 1x1x1 again
        Vector3 objectScale = gameObject.transform.localScale;
        objectScale.x /= transform.localScale.x;
        objectScale.y /= transform.localScale.y;
        objectScale.z /= transform.localScale.z;
        gameObject.transform.localScale = objectScale;

        return gameObject;
    }

    protected Vector3 GetSpawnPosition(int track, int numberOfTracks) {
        // Planes have size 10
        float trackSize = 10F / numberOfTracks;
        // Choose random track

        // Then, -5 is the border of a plane, and center the object in the "track"
        return new Vector3(-5F + trackSize / 2F + track * trackSize, 0F, 5F);
    }
}
