using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CloningTile : BaseTile {
    // Cloning devices
    [Header("Cloning Arc setup")]
    [SerializeField] SpawnableObjects cloningArc;

    private GameObject[] _cloners;

    void Start() {
        _cloners = new GameObject[_tracks];
        SpawnRowOfCloners();
    }

    void SpawnRowOfCloners() {
        var activeClonerTrack = UnityEngine.Random.Range(0, _tracks);

        for (int track = 0; track < _tracks; track++) {
            GameObject cloner = SpawnGameObject(cloningArc.GetObjectToSpawn(), track, _tracks);
            cloner.GetComponent<ClonningDoor>()?.SetCloningStatus(track == activeClonerTrack);
            cloner.GetComponent<ClonningDoor>()?.SetClonerWorldPosition(GetSpawnPosition(track, _tracks), gameObject.transform);
            _cloners[track] = cloner;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            RequestForCloneCreation();
        }
    }

    public void RequestForCloneCreation() {
        var nextAvailableCloningPosition = GetNextAvailableCloningPosition();
        if (nextAvailableCloningPosition != null) {
            AudioManager.Instance.Play("CloneSound");
            ClonesManager.Instance.CreateClone((Vector3) nextAvailableCloningPosition);
        }
    }

    private Vector3? GetNextAvailableCloningPosition() {
        GameObject activeCloner = Array.Find(_cloners, cloner => cloner.GetComponent<ClonningDoor>()?.IsActiveCloner() == true);
        if (activeCloner != null && activeCloner.GetComponent<ClonningDoor>()?.CanClone() == true) {
            return activeCloner.GetComponent<ClonningDoor>().GetClonerWorldPosition();
        } else {
            GameObject[] availableCloners = Array.FindAll(_cloners, cloner => cloner.GetComponent<ClonningDoor>()?.CanClone() == true);
            if (availableCloners.Length > 0) {
                var nextAvailableCloner = availableCloners[UnityEngine.Random.Range(0, availableCloners.Length)];
                return nextAvailableCloner.GetComponent<ClonningDoor>().GetClonerWorldPosition();
            } else {
                return null;
            }
        }
    }
}
