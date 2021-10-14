using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossModifications : NetworkBehaviour
{
    [SyncVar]
    public int damageDealtModPercent = 100; // ex: at 110 will do 10% more DMG

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
