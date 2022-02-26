using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonerManager : MonoBehaviour
{
    [SerializeField] private Color _canCloneColor = new Color(0, 149, 229);
    [SerializeField] private Color _canNotCloneColor = new Color(0, 58, 229);

    private bool _canClone;
    private Vector3 _activeClonerPosition;

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

    // Sets the active cloner position relative to world space
    public void SetActiveClonerPosition(Vector3 activeClonerPosition, Transform parentTransform) {
        _activeClonerPosition = parentTransform.TransformPoint(activeClonerPosition);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player") && _activeClonerPosition != null) {
            // TODO: Clone the player car
            ClonesManager.Instance.CreateClone(_activeClonerPosition);
            AudioManager.Instance.Play("CloneSound");
        }
    }
}
