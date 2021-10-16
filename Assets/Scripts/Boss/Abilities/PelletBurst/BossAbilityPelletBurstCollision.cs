using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAbilityPelletBurstCollision : NetworkBehaviour
{
    int DAMAGE = 5;

    // ServerCallback because we don't want a warning if OnTriggerEnter is
    // called on the client
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
