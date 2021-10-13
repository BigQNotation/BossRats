using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerStats : NetworkBehaviour
{
    [SyncVar]
    private int currentPlayerHealth = 100;
    private int maxPlayerHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCurrentPlayerHealth()
    {
        return currentPlayerHealth;
    }
    public int GetMaxPlayerHealth()
    {
        return maxPlayerHealth;
    }
}
