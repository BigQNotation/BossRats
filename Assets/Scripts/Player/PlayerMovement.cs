using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    [SyncVar]
    public float runSpeed = 20.0f;
    Rigidbody2D body;
    float horizontal;
    float vertical;
    public Camera cam;
    Vector2 mousePos;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }
    void Update()
    {
        if (!isLocalPlayer) { return; }
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        if (!isLocalPlayer) { return; }
        body.velocity = new Vector2(horizontal, vertical).normalized *runSpeed;
        Vector2 lookDir = mousePos - body.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        body.rotation = angle;
    }

}
