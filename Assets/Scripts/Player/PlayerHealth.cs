using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : BaseHealth
{
    public override void Die()
    {
        Invoke("Restart", 2);
    }

    private void Restart()
    {
        GameManager.Instance.Restart();
    }
}
