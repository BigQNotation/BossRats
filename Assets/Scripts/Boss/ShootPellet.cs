using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPellet : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float force = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.AddForce(transform.up * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
