using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTouch : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GameManager.inst.AddPoints(1);
        // TODO: add "shine"/blow-up effect before dissapearing?
        Destroy(gameObject, 0.1f);
    }
}
