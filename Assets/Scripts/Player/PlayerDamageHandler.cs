using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PlayerDamageHandler handles damage
 * to be received by player from boss
 * projectiles.
 */
public class PlayerDamageHandler : MonoBehaviour
{
    public void TakeDamage(float damage)
    {
        float totalDamage = GetTotalDamage(damage);
        gameObject.GetComponent<PlayerStats>().DecrementPlayerHealth(totalDamage);
    }

    private float GetTotalDamage(float rawPlayerDamage)
    {
        return (((float)GameObject.Find("Boss").GetComponent<BossModifications>().damageDealtModPercent / 100) * (float)rawPlayerDamage);
    }
}
