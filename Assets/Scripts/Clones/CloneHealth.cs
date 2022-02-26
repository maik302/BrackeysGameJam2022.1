using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneHealth : MonoBehaviour {
    [SerializeField] private int _healthPoints = 1;

    public void Hit(int hitDamage) {
        _healthPoints -= hitDamage;

        if (_healthPoints <= 0) {
            ClonesManager.Instance.RemoveAClone();
            Destroy(gameObject);
        }
    }
}
