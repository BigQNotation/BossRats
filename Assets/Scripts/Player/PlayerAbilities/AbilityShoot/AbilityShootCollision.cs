using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AbilityShootCollision : NetworkBehaviour
{
    float DAMAGE = 10;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Boss"))
        {
            GameObject.Find("Boss").GetComponent<BossDamageHandler>().TakeDamage(DAMAGE);
            
            PlayerStatTracker playerStatTracker = GameObject.Find("PlayerStatTracker").GetComponent<PlayerStatTracker>();

            //Debug.Log(PlayerStatTracker.playerStats[0].playerID);

            foreach (PlayerStatTracker.PlayerStat playerStat in PlayerStatTracker.playerStats)
            {
                Debug.Log("thatsa one check meboyo");
                Debug.Log("player stat player id: " + playerStat.playerID);
                Debug.Log("player projectile origin player id " + gameObject.GetComponent<PlayerProjectileOrigin>().playerID);
                if (playerStat.playerID == gameObject.GetComponent<PlayerProjectileOrigin>().playerID)
                {
                    Debug.Log("nice! found a match.");
                }
            }

            Debug.Log("User " + gameObject.GetComponent<PlayerProjectileOrigin>().playerID + " " + DAMAGE);
            
            Destroy(gameObject);
        }
    }
}