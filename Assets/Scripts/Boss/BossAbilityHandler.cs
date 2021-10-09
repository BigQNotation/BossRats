using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAbilityHandler : NetworkBehaviour
{
    private BossAbility[] abilityList;
    

    void Start()
    {
        if (!isServer)
            return;

        GetAbilityConfiguration();
        Debug.Log("Ability selected: " + abilityList[0]);
    }
    void Update()
    {
        if (!isServer)
            return;

        UseAbilities();

    }
    private void GetAbilityConfiguration()
    {
        gameObject.GetComponent<BossAbilityConfigGenerator>().GenerateRandomAbilityList(1);
        abilityList = gameObject.GetComponent<BossAbilityConfigGenerator>().GetRandomAbilityList();
    }
    private void UseAbilities()
    {
        for (int i = 0; i < abilityList.Length; i++)
        {
            abilityList[i].DecrementCooldown();

            if (abilityList[i].AbilityReady())
            {
                abilityList[i].UseAbility();
                abilityList[i].ResetCooldown();
            }
        }

    }

}
