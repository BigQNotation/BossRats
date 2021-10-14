using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AbilityShootCollision : NetworkBehaviour
{
    int DAMAGE = 10;

    // ServerCallback because we don't want a warning if OnTriggerEnter is
    // called on the client
    [ServerCallback]
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Boss"))
        {
            GameObject.Find("Boss").GetComponent<BossDamageHandler>().TakeDamage(DAMAGE);
            NetworkServer.Destroy(gameObject);
        }

    }

}
