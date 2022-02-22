using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class BossHealthUI : NetworkBehaviour
{
    [SerializeField]
    GameObject boss;
    [SerializeField]
    GameObject healthBar;
    [SyncVar]
    float bossHealth;

    void Start()
    {        
    }
    void Update()
    {
        if (isServer)
            bossHealth = GetBossHealth();
        
        SetBossHealthUI(bossHealth);
    }

    private float GetBossHealth()
    {
        return boss.GetComponent<BossStats>().GetBossHealth();
    }
    private void SetBossHealthUI(float health)
    {
        healthBar.GetComponent<Healthbar>().SetHealth((int)health);
    }
}
