﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAbilityBigSlowPelletCollision : NetworkBehaviour
{
    int DAMAGE = 10;

    void OnTriggerEnter2D(Collider2D playerCollider)
    {
        
        if (playerCollider.CompareTag("Player"))
        {
            playerCollider.gameObject.GetComponent<PlayerDamageHandler>().TakeDamage(DAMAGE);
            Destroy(gameObject);
        }

    }
}
