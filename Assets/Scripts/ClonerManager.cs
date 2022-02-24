using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonerManager : MonoBehaviour
{
    [SerializeField] private Color _canCloneColor;
    [SerializeField] private Color _canNotCloneColor;
    public void SetCloningStatus(bool canClone) {
        var cloningGate = transform.Find("CloningGate");
        var cloningGateSignal = transform.Find("CloningGateSignal");

        if (cloningGate != null && cloningGateSignal != null) {
            cloningGate.GetComponent<Renderer>()?.material.SetColor("_Color", canClone ? _canCloneColor : _canNotCloneColor);
            cloningGateSignal.GetComponent<Renderer>()?.material.SetColor("_Color", canClone ? _canCloneColor : _canNotCloneColor);
        }
    }
}
