using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAbilityHandler : NetworkBehaviour
{
    private BossAbility[] abilityList;
    [SerializeField] GameObject playerLoadHandler;

    private void Start()
    {
        if (!isServer)
            return;

        GetAbilityConfiguration();
        Debug.Log("Ability selected: " + abilityList[0]);
    }
    private void Update()
    {
        if (!isServer || !playerLoadHandler.GetComponent<PlayerLoadHandler>().ArePlayersLoaded())
            return;
        UpdateAbilityCooldowns();
        TryUseAbilities();
    }
    private void GetAbilityConfiguration()
    {
        gameObject.GetComponent<BossAbilityConfigGenerator>().GenerateRandomAbilityList(3);
        abilityList = gameObject.GetComponent<BossAbilityConfigGenerator>().GetRandomAbilityList();
    }
    private void UpdateAbilityCooldowns()
    {
        for (int i = 0; i < abilityList.Length; i++)
            abilityList[i].DecrementCooldown();
    }
    private void TryUseAbilities()
    {
        for (int i = 0; i < abilityList.Length; i++)
        {
            if (abilityList[i].AbilityReady())
                UseAbility(abilityList[i]);
        }
    }
    private void UseAbility(BossAbility ability)
    {
        ability.UseAbility();
        ability.ResetCooldown();

        RpcClientUseAbility(ability);
    }
    [ClientRpc(includeOwner = false)] private void RpcClientUseAbility(BossAbility ability)
    {
        if (!isServer)
        {
            ability.UseAbility();
            ability.ResetCooldown();
        }

    }
}
