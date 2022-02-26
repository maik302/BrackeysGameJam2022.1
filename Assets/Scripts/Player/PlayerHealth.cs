using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : BaseHealth
{
    public override int BeforeHit(int hitDamage) {
        if (ClonesManager.Instance.IsEmpty()) {
            return hitDamage;
        } else {
            ClonesManager.Instance.RemoveAllClones();
            return 0;
        }
    }

    public override void Die()
    {
        Invoke("Restart", 2);
    }

    private void Restart()
    {
        GameManager.Instance.Restart();
    }
}
