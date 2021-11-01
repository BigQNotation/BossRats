using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class BossAbilityAreaTimeBombCollision : NetworkBehaviour
{
    float DAMAGE = 3;

    void OnTriggerEnter2D(Collider2D playerCollider)
    {
        

        if (playerCollider.CompareTag("Player"))
        {
            if (!playerCollider.gameObject.GetComponent<NetworkIdentity>().isLocalPlayer)
                return;

            playerCollider.gameObject.GetComponent<PlayerDamageHandler>().CmdTakeDamage(DAMAGE);
            Destroy(gameObject);
        }

    }
}
