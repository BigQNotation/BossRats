using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbilityPelletMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    private readonly float force = 200f;
    void Start()
    {
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    public void AddForce(Vector2 amount)
    {
        rigidBody.AddForce(amount * force);
    }
}
