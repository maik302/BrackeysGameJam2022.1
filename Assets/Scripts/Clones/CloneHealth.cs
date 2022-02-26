using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneHealth : BaseHealth
{
    public override int BeforeHit(int hitDamage)
    {
        return hitDamage;
    }

    public override void Die()
    {
        ClonesManager.Instance.RemoveAClone(gameObject);
    }
}
