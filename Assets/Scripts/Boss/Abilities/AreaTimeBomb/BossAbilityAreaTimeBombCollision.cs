using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbilityAreaTimeBombCollision : MonoBehaviour
{
    float DAMAGE = 3;

    void OnTriggerEnter2D(Collider2D playerCollider)
    {

        if (playerCollider.CompareTag("Player"))
        {
            playerCollider.gameObject.GetComponent<PlayerDamageHandler>().TakeDamage(DAMAGE);
            Destroy(gameObject);
        }

    }
}
