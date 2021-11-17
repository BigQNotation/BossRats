using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAbilityHandler : NetworkBehaviour
{
    private BossAbility[] abilityList;
    [SerializeField] GameObject playerLoadHandler;
    private BossModifications bossModifications;

    public BossAbility[] GetAbilityList()
    {
        return abilityList;
    }

    private void Start()
    {
        if (!isServer)
            return;

        bossModifications = gameObject.GetComponent<BossModifications>();

        GetAbilityConfiguration();
        SaveAbilityListConfiguration();
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
        if (PlayerPrefs.GetInt("PlayerDesiresNewBoss", 0) != 1)
        {
            gameObject.GetComponent<BossAbilityConfigGenerator>().GenerateRandomAbilityList(3);
            abilityList = gameObject.GetComponent<BossAbilityConfigGenerator>().GetRandomAbilityList();
        }
        else
        {
            gameObject.GetComponent<BossSavedConfiguration>().LoadAbilities();
            int[] abilityIDs = gameObject.GetComponent<BossSavedConfiguration>().GetBossAbilityIDs();
            abilityList = gameObject.GetComponent<BossAbilityConfigGenerator>().GetAbilityListByIDs(abilityIDs);
        }
        
    }

    private void SaveAbilityListConfiguration() 
    {
        List<int> abilityIDs = new List<int>();
        for (int i = 0; i < abilityList.Length; i++)
        {
            abilityIDs.Add(abilityList[i].GetAbilityID());
        }

        gameObject.GetComponent<BossSavedConfiguration>().SaveBossAbilityIDs(abilityIDs.ToArray());
    }
    private void UpdateAbilityCooldowns()
    {
        for (int i = 0; i < abilityList.Length; i++)
            abilityList[i].DecrementCooldown(Time.deltaTime * bossModifications.cooldownMultiplier);
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
