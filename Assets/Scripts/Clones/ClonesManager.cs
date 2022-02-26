using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonesManager : MonoBehaviour {
    public static ClonesManager Instance;

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _clonePrefab;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        }
    }

    public void CreateClone(Vector3 spawnPosition) {
        var clone = Instantiate(_clonePrefab);
        clone.transform.position = new Vector3(spawnPosition.x, _playerTransform.position.y, _playerTransform.position.z);
    }
}
