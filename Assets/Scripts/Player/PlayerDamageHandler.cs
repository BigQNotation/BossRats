using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
/*
 * PlayerDamageHandler handles damage
 * to be received by player from boss
 * projectiles.
 */
public class PlayerDamageHandler : NetworkBehaviour
{
    [Command]
    public void CmdTakeDamage(float damage)
    {
        float totalDamage = GetTotalDamage(damage);
        gameObject.GetComponent<PlayerStats>().DecrementPlayerHealth(totalDamage);
    }

    private float GetTotalDamage(float rawPlayerDamage)
    {
        return (((float)GameObject.Find("Boss").GetComponent<BossModifications>().damageDealtModPercent / 100) * (float)rawPlayerDamage);
    }
}
