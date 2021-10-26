using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAbilityRapidPelletsCollision : NetworkBehaviour
{
    int DAMAGE = 2;

    [ServerCallback]
    void OnTriggerEnter2D(Collider2D playerCollider)
    {

        if (playerCollider.CompareTag("Player"))
        {
            playerCollider.gameObject.GetComponent<PlayerDamageHandler>().TakeDamage(DAMAGE);
            NetworkServer.Destroy(gameObject);
        }

    }
}
