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
        AudioManager.Instance.Stop("CarEngineSound");
        Invoke("GameOver", 0.5f);
    }

    private void GameOver()
    {
        GameManager.Instance.SetGameState(GameManager.GameState.GAME_OVER);
    }
}
