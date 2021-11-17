using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LobbySettings : NetworkBehaviour
{
    public bool server = false;
    private void Update()
    {
        if (isServer)
            server = true;
        if (!isServer)
            server = false;

    }
}
