using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsManager : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] private float _upwardsWhenEnding = 10f;
    [SerializeField] private int _pointsValue = 1;
    
    private float _upwardsSpeed = 0;

    void Update()
    {
        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * _upwardsSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("PlayerClone")) {
            GameManager.inst.AddPoints(_pointsValue);

            // Destruction animation
            _rotationSpeed *= 100;
            _upwardsSpeed = _upwardsWhenEnding;

            // Play pickup sound
            AudioManager.Instance.Play("CoinSound");

            Destroy(gameObject, 0.5f);
        }
    }

}
