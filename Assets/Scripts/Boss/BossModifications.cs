﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossModifications : NetworkBehaviour
{
    [SyncVar] public float damageDealtModPercent = 100; // ex: at 110 will do 10% more DMG
    [SyncVar] public float healthRegeneration = 0;

    void Start()
    {
        gameObject.AddComponent<ModificationHealthRegen>();
    }

    void Update()
    {

    }


}
