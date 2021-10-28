using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbilityRapidPelletsMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    private readonly float force = 200f;

    public void AddForce(Vector2 vector)
    {
        rigidBody.AddForce(vector * force);

    }
    private void Start()
    {
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
