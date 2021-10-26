using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AbilityShootCollision : NetworkBehaviour
{
    int DAMAGE = 10;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Boss"))
        {
            GameObject.Find("Boss").GetComponent<BossDamageHandler>().TakeDamage(DAMAGE);
            Destroy(gameObject);
        }

    }

}
