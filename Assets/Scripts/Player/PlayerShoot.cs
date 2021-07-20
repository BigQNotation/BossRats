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
        HandleAbilityKeyPress();

    }

    private void HandleAbilityKeyPress()
    {
        for (int i = 0; i < abilityKey.Length; i++)
        {
            if (Input.GetKeyDown(abilityKey[i]))
                CmdAbility(PlayerPrefs.GetInt("AbilityKey_" + i.ToString()));
        }
    }

    [Command]
    private void CmdAbility(int abilityKey)
    {
        Ability myabil = gameObject.GetComponent<Ability>();
        myabil.UseAbility(abilityKey);

    }
}
