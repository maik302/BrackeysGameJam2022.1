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

    private List<GameObject> clones;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        }

        clones = new List<GameObject>(_maxClones);
    }

    public void CreateClone(Vector3 spawnPosition) {
        if (clones.Count < _maxClones) {
            var clone = Instantiate(_clonePrefab);
            clone.transform.position = new Vector3(spawnPosition.x, _playerTransform.position.y, _playerTransform.position.z);

            clones.Add(clone);
        }
    }

    public bool IsEmpty() {
        return clones.Count == 0;
    }

    public void RemoveAllClones() {
        while (! IsEmpty()) {
            RemoveAClone();
        }
    }

    public void RemoveAClone() {
        GameObject clone = clones[0];
        RemoveAClone(clone);
    }

    public void RemoveAClone(GameObject clone) {
        clones.Remove(clone);
        Destroy(clone);
    }

    public void SetClonesHorizontalMovementState(bool canMoveHorizontally) {
        foreach (GameObject clone in clones) {
            clone.GetComponent<CloneMovement>()?.SetCanMoveHorizontally(canMoveHorizontally);
        }
    }
}
