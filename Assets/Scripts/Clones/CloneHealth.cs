using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneHealth : BaseHealth
{
    public override void Die()
    {
        ClonesManager.Instance.RemoveAClone();
        Destroy(gameObject);
    }
}
