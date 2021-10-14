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

    // set velocity for server and client. this way we don't have to sync the
    // position, because both the server and the client simulate it.
    void Start()
    {
        if (isServer)
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        rigidBody.AddForce(transform.up * force);

    }

    // destroy for everyone on the server
    [Server]
    void DestroySelf()
    {
        NetworkServer.Destroy(gameObject);
    }


}
