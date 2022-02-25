using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonerManager : MonoBehaviour
{
    [SerializeField] private Color _canCloneColor = new Color(0, 149, 229);
    [SerializeField] private Color _canNotCloneColor = new Color(0, 58, 229);

    private bool _canClone;

    public void SetCloningStatus(bool canClone) {
        var cloningGate = transform.Find("CloningGate");
        var cloningGateSignal = transform.Find("CloningGateSignal");

        if (cloningGate != null && cloningGateSignal != null) {
            cloningGate.GetComponent<Renderer>()?.material.SetColor("_Color", canClone ? _canCloneColor : _canNotCloneColor);
            cloningGateSignal.GetComponent<Renderer>()?.material.SetColor("_Color", canClone ? _canCloneColor : _canNotCloneColor);

            _canClone = canClone;
        }
    }

    public bool CanClone() {
        return _canClone;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            // TODO: Clone the player car

            AudioManager.Instance.Play("CloneSound");
        }
    }
}
