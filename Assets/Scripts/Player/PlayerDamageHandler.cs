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
    public void TakeDamage(int damage)
    {
        int totalDamage = GetTotalDamage(damage);
        gameObject.GetComponent<PlayerStats>().DecrementPlayerHealth(damage);
    }

    private int GetTotalDamage(int rawPlayerDamage)
    {
        return ((GameObject.Find("Boss").GetComponent<BossModifications>().damageDealtModPercent / 100) * rawPlayerDamage);
    }


}
