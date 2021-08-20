using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    private Ability[] abilityList;
    private Ability[] selectedAbilityList;

    // Start is called before the first frame update
    void Start()
    {
        CreateAbilityList();
        CreateSelectedAbilityList();
    }

    // Update is called once per frame
    void Update()
    {



    }

    public Ability[] GetAbilityList()
    {
        return abilityList;
    }

    public Ability[] GetSelectedAbilityList()
    {
        return selectedAbilityList;
    }
    private void CreateAbilityList()
    {
        Ability[] allAbilities = { gameObject.GetComponent<AbilityShoot>(), gameObject.GetComponent<AbilitySpeedboost>(), gameObject.GetComponent<AbilityBlink>() };
        abilityList = allAbilities;
    }
    private void CreateSelectedAbilityList()
    {
        Ability[] selectedAbilities = { null, null, null };
        int abilityOneKey = PlayerPrefs.GetInt("AbilityKey_0");
        int abilityTwoKey = PlayerPrefs.GetInt("AbilityKey_1");
        int abilityThreeKey = PlayerPrefs.GetInt("AbilityKey_2");

        foreach (Ability ability in abilityList)
        {
            if (ability.GetAbilityID() == abilityOneKey)
            {
                selectedAbilities[0] = ability;
            }
            if (ability.GetAbilityID() == abilityTwoKey)
            {
                selectedAbilities[1] = ability;
            }
            if (ability.GetAbilityID() == abilityThreeKey)
            {
                selectedAbilities[2] = ability;
            }


        }
        if (selectedAbilities[0] != null && selectedAbilities[1] != null && selectedAbilities[2] != null)
        {
            selectedAbilityList = selectedAbilities;
        }
        else
        {
            Debug.Log("ERROR in AbilityManager CreateSelectedAbilityList()");
        }

    }
}
