using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonningDoor : MonoBehaviour
{
    [SerializeField] private Color _activeClonerColor = new Color(0, 149, 229);
    [SerializeField] private Color _inactiveClonerColor = new Color(0, 58, 229);

    private bool _isActiveCloner;
    private Vector3 _clonerWorldPosition;
    private bool _canClone;

    private void Awake() {
        _canClone = true;
    }

    public void SetCloningStatus(bool isActiveCloner) {
        var cloningGate = transform.Find("CloningGate");
        var cloningGateSignal = transform.Find("CloningGateSignal");

        if (cloningGate != null && cloningGateSignal != null) {
            cloningGate.GetComponent<Renderer>()?.material.SetColor("_Color", isActiveCloner ? _activeClonerColor : _inactiveClonerColor);
            cloningGateSignal.GetComponent<Renderer>()?.material.SetColor("_Color", isActiveCloner ? _activeClonerColor : _inactiveClonerColor);
            _isActiveCloner = isActiveCloner;
        }
    }

    public bool IsActiveCloner() {
        return _isActiveCloner;
    }

    public void SetClonerWorldPosition(Vector3 localClonerPosition, Transform parentTransform) {
        _clonerWorldPosition = parentTransform.TransformPoint(localClonerPosition);
    }

    public Vector3 GetClonerWorldPosition() {
        return _clonerWorldPosition;
    }

    public bool CanClone() {
        return _canClone;
    }

    private void OnTriggerEnter(Collider other) {
        // Sets that the cloner has an object in it, so another one cannot be created in its transform position
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("PlayerClone")) {
            _canClone = false;
        }
    }
}
