using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    [SyncVar]
    public float runSpeed = 6f;
    Rigidbody2D body;
    float horizontal;
    float vertical;
    public Camera cam;
    Vector2 mousePos;
    GameObject playerLoadHandler;

    void Start()
    {
        if (isLocalPlayer)
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        body = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        playerLoadHandler = GameObject.Find("PlayerLoadHandler");
        if (playerLoadHandler == null)
            Debug.Log("ERROR: Could not find PlayerLoadHandler");

    }
    void Update()
    {
        if (!isLocalPlayer || !playerLoadHandler.GetComponent<PlayerLoadHandler>().ArePlayersLoaded())
            return;
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
