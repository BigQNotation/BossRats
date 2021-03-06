using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbilityBigSlowPelletMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    private readonly float force = 100f;

    void Start()
    {
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }  

    public void AddForce(Vector2 vector)
    { 
        rigidBody.AddForce(vector * force);
        
    }
}
