using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerCamera : NetworkBehaviour
{
    void Update()
    {
        if (!isLocalPlayer) return;
        Camera.main.transform.position = transform.position + (new Vector3(0, 0, -1));
        Camera.main.transform.LookAt(transform);
    }
}
