using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] private int _healthPoints = 100;

    public void Hit(int hitDamage) {
        _healthPoints -= hitDamage;
        // TODO: Manage when hitpoints reach to 0
    }
}
