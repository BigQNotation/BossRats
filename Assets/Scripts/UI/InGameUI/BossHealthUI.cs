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
    GameObject healthTextObject;
    [SyncVar]
    string bossHealthText;

    void Start()
    {        
    }
    void Update()
    {
        if (isServer)
            bossHealthText = GetBossHealth();
        
        SetBossHealthUI(bossHealthText);
    }

    private string GetBossHealth()
    {
        return boss.GetComponent<BossStats>().GetBossHealth().ToString();
    }
    private void SetBossHealthUI(string healthText)
    {
        healthTextObject.GetComponent<Text>().text = healthText;
    }
}
