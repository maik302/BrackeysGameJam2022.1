using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonesManager : MonoBehaviour {
    public static ClonesManager Instance;

    [Header("Player")]
    [SerializeField] private Transform _playerTransform;

    [Header("Clones")]
    [SerializeField] private GameObject _clonePrefab;
    [SerializeField] private int _maxClones;

    private int _createdClones;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        }

        _createdClones = 0;
    }

    public void CreateClone(Vector3 spawnPosition) {
        if (_createdClones < _maxClones) {
            var clone = Instantiate(_clonePrefab);
            clone.transform.position = new Vector3(spawnPosition.x, _playerTransform.position.y, _playerTransform.position.z);
            
            _createdClones++;
        }
    }

    public void RemoveAClone() {
        _createdClones--;
    }
}
