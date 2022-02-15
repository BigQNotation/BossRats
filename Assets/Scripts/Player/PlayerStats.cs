using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerStats : NetworkBehaviour
{
    [SyncVar]
    private float currentPlayerHealth = 3000;
    private float maxPlayerHealth = 100;

    [SyncVar]
    public string playerName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetCurrentPlayerHealth()
    {
        return currentPlayerHealth;
    }
    public float GetMaxPlayerHealth()
    {
        return maxPlayerHealth;
    }
    public string GetPlayerName()
    {
        return playerName;
    }
    public void DecrementPlayerHealth(float healthDec)
    {
        currentPlayerHealth -= healthDec;
    }
}
