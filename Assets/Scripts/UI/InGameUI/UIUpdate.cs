using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class UIUpdate : NetworkBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;
        GameObject abilityOne = GameObject.Find("AbilityOneUI");
        GameObject abilityTwo = GameObject.Find("AbilityTwoUI");
        GameObject abilityThree = GameObject.Find("AbilityThreeUI");

        abilityOne.GetComponent<Text>().text = gameObject.GetComponent<AbilityManager>().GetSelectedAbilityList()[0].cooldownRemainder.ToString();
        abilityTwo.GetComponent<Text>().text = gameObject.GetComponent<AbilityManager>().GetSelectedAbilityList()[1].cooldownRemainder.ToString();
        abilityThree.GetComponent<Text>().text = gameObject.GetComponent<AbilityManager>().GetSelectedAbilityList()[2].cooldownRemainder.ToString();


    }
}
