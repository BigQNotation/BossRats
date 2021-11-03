﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAbilityPelletCollision : NetworkBehaviour
{
    float DAMAGE = 3;

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
