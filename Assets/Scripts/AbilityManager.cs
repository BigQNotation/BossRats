using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    private Ability[] abilityList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ability[] allAbilities = { gameObject.GetComponent<AbilityShoot>(), gameObject.GetComponent<AbilitySpeedboost>() };
        abilityList = allAbilities;
    }

    public Ability[] GetAbilityList()
    {
        return abilityList;
    }
}
