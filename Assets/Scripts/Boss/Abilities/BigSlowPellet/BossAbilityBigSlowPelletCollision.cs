using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAbilityBigSlowPelletCollision : NetworkBehaviour
{
    float DAMAGE = 2;

    void OnTriggerEnter2D(Collider2D playerCollider)
    {

        if (playerCollider.CompareTag("Player"))
        {
            if (playerCollider.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer)
                playerCollider.gameObject.GetComponent<PlayerDamageHandler>().CmdTakeDamage(DAMAGE);
            Destroy(gameObject);
        }

    }
}
