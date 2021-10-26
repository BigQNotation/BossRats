using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
 
public class AbilityShootMovement : NetworkBehaviour
{
    public float destroyAfter = 50;
    public Rigidbody2D rigidBody;
    public float force = 500f;

    public override void OnStartServer()
    {
        Invoke(nameof(DestroySelf), destroyAfter);
    }

    void Start()
    {
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        rigidBody.AddForce(transform.up * force);
    }

    [Server]
    void DestroySelf()
    {
        NetworkServer.Destroy(gameObject);
    }
}
