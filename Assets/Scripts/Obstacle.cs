using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	[SerializeField] private int _hitDamage;

	private void OnTriggerEnter(Collider other) {
		var collisionObject = other.gameObject;
		if (collisionObject.CompareTag("Player")) {
			AudioManager.Instance.Play("CarHit");
			collisionObject.GetComponent<PlayerHealth>()?.Hit(_hitDamage);
        } else if (collisionObject.CompareTag("PlayerClone")) {
			collisionObject.GetComponent<CloneHealth>()?.Hit(_hitDamage);
        }
	}
}
