using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAbilityBigSlowPelletCollision : NetworkBehaviour
{
    int DAMAGE = 10;

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
