using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerCamera : NetworkBehaviour
{
    private Transform playerTransform;

    public void SetPlayerToSpectate(Transform player)
    {
        playerTransform = player;
    }
    public void ResetPlayerToSpectate()
    {
        playerTransform = transform;
    }

    private void Start()
    {
        playerTransform = transform;
    }
    private void Update()
    {
        if (!isLocalPlayer) return;

        ViewPlayer();
    }
    private void ViewPlayer()
    {
        Camera.main.transform.position = playerTransform.position + (new Vector3(0, 0, -1));
        Camera.main.transform.LookAt(playerTransform);
    }
}
