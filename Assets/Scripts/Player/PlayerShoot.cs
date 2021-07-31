using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

/*
 * PlayerShoot checks if user has pressed an ability key then
 * finds the ability that user chose for that ability key then
 * tells server to deal with it.
 */
public class PlayerShoot : NetworkBehaviour
{
    private KeyCode[] abilityKey = { KeyCode.Mouse0, KeyCode.Mouse1, KeyCode.LeftShift};
    private const int MAX_POSSIBLE_ABILITY_COUNT = 9999;

    private void Start()
    {
        // this will be refactored out into player ability selection scene
        PlayerPrefs.SetInt("AbilityKey_0", 15);
        PlayerPrefs.SetInt("AbilityKey_1", 90);
        PlayerPrefs.SetInt("AbilityKey_2", 33);
    }

    void Update()
    {
        if (!isLocalPlayer) return;
        Ability[] allAbilities = { gameObject.GetComponent<AbilityShoot>(), gameObject.GetComponent<AbilitySpeedboost>() };
        //Ability[] allAbilities = gameObject.GetComponent<AbilityManager>().GetAbilityList();
        CmdUseAbility(allAbilities, FindMatchingAbilityID(DetectAbilityKeyCodePress()));
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
                return i;  
        }
        return -1;
    }

    private int FindMatchingAbilityID(int abilityKeyCodeIndex)
    {
        if (abilityKeyCodeIndex != -1)
            return PlayerPrefs.GetInt("AbilityKey_" + abilityKeyCodeIndex.ToString());
        else
            return -1; 
    }

    [Command]
    private void CmdUseAbility(Ability[] abil, int abilID)
    {
        if (abilID != -1)
        {
            for (int i = 0; i < abil.Length; i++)
            {
                if (abilID == abil[i].GetAbilityID())
                {
                    if (abil[i].AbilityReady())
                    {
                        abil[i].UseAbility();
                        abil[i].ResetCooldown();
                    }
                }
            }
        }

    }
}

