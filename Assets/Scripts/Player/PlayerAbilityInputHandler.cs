using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

/*
 * PlayerAbilityInputHandler checks if user has pressed an ability key then
 * finds the ability that user chose for that ability key then
 * tells server to deal with it.
 */
public class PlayerAbilityInputHandler : NetworkBehaviour
{
    private KeyCode[] abilityKey = { KeyCode.Mouse0, KeyCode.Mouse1, KeyCode.LeftShift};
    private const int MAX_POSSIBLE_ABILITY_COUNT = 9999;
    [SerializeField] GameObject playerLoadHandler;

    private void Start()
    {
        // this will be refactored out into player ability selection scene
        //PlayerPrefs.SetInt("AbilityKey_0", 15);
        //PlayerPrefs.SetInt("AbilityKey_1", 90);
        //PlayerPrefs.SetInt("AbilityKey_2", 33);
        playerLoadHandler = GameObject.Find("PlayerLoadHandler");
        if (playerLoadHandler == null)
            Debug.Log("ERROR: Could not find PlayerLoadHandler");
        
    }
    private void Update()
    {
        if (!isLocalPlayer || !playerLoadHandler.GetComponent<PlayerLoadHandler>().ArePlayersLoaded())
            return;
        Ability[] allAbilities = gameObject.GetComponent<AbilityManager>().GetAbilityList();
        if (NetworkClient.ready && DetectAbilityKeyCodePress() != -1)
            {
                Ability abil = GetAbilityToUse(allAbilities, GetMatchingAbilityID(DetectAbilityKeyCodePress()));
                if (abil != null)
                    TryUseAbility(abil, GetUserMouseCoordinates() );
            }
            
    }
    [ClientCallback]
    private void TryUseAbility(Ability abil, float[] userMouseInputs)
    {
        
        if (CanUseAbility(abil))
        {
            CmdTryUseAbility(abil, userMouseInputs);
            ClientUseAbility(abil, userMouseInputs);
        }
    }
    private bool CanUseAbility(Ability abilToUse)
    {
        if (abilToUse.AbilityReady())
            return true;
        return false;
        
    }
    private Ability GetAbilityToUse(Ability[] abil, int abilID)
    {
        if (abilID != -1)
        {
            for (int i = 0; i < abil.Length; i++)
            {
                if (abilID == abil[i].GetAbilityID())
                {
                        return abil[i];
                   
                }
            }
        }
        return null;
    }
    [Command] private void CmdTryUseAbility(Ability abil, float[] userMouseInputs)
    {
        if (CanUseAbility(abil))
        {
            RpcAllClientsUseAbility(abil, userMouseInputs);
            ServerUseAbility(abil, userMouseInputs);
        }
    }
    [ClientRpc(includeOwner = false)] private void RpcAllClientsUseAbility(Ability abil , float[] userMouseInputs)
    {
        ClientUseAbility(abil , userMouseInputs);
    }
    private void ServerUseAbility(Ability abil, float[] userMouseInputs)
    {
        if (isServer)
        {
            abil.ResetCooldown();
            gameObject.GetComponent<RecordAbilitiesUsed>().UpdateRecordedMetric();
            GameObject.Find("Boss").GetComponent<BossMovementAggroHandler>().AddPlayerAggro(gameObject, 1);
        }
    }
    private void ClientUseAbility(Ability abil, float[] userMouseInputs)
    {
        if (isClient)
        {
            abil.UseAbility(userMouseInputs[0], userMouseInputs[1]);
        }
    }
    private int GetMatchingAbilityID(int abilityKeyCodeIndex)
    {
        if (abilityKeyCodeIndex != -1)
            return PlayerPrefs.GetInt("AbilityKey_" + abilityKeyCodeIndex.ToString());
        else
            return -1;
    }
    private int DetectAbilityKeyCodePress()
    {
        /*note if user has more than one 
        * abilityKey KeyCode pressed down
        * only one of their indices will
        * be returned.
        */
        for (int i = 0; i < abilityKey.Length; i++)
        {
            if (Input.GetKeyDown(abilityKey[i]))
            {
                return i;
            }

        }
        return -1;
    }
    private float [] GetUserMouseCoordinates()
    {
        float xPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float yPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        return (new float [2] { xPos, yPos});
    }
 
}

