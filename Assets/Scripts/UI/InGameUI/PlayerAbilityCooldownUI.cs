using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PlayerAbilityCooldownUI : NetworkBehaviour
{
    GameObject[] abilityCooldownSliderObjects = new GameObject[3];
    GameObject[] abilityCooldownTextObjects = new GameObject[3];
    int[] CeilingsOfAbilityCooldownRemainders = new int[3];

    void Start()
    {
        FindAndSetAbilitySliderObjects();
        SetSliderObjectsMaxValue();
    }
    void Update()
    {
        if (!isLocalPlayer)
            return;

        FindAndSetAbilityCooldownTextObjects();
        SetSlidersToCurrentCooldownRemainder();
        SetAbilityCeilingCooldownRemainders();
        SetCooldownTextObjectsToCeilingOfCooldownRemainders();
    }
    private void FindAndSetAbilitySliderObjects()
    {
        abilityCooldownSliderObjects[0] = GameObject.Find("AbilityOneCooldownUI");
        abilityCooldownSliderObjects[1] = GameObject.Find("AbilityTwoCooldownUI");
        abilityCooldownSliderObjects[2] = GameObject.Find("AbilityThreeCooldownUI");
    }
    private void SetSliderObjectsMaxValue()
    {
        abilityCooldownSliderObjects[0].GetComponent<Slider>().maxValue = gameObject.GetComponent<AbilityManager>().GetSelectedAbilityList()[0].cooldownCap;
        abilityCooldownSliderObjects[1].GetComponent<Slider>().maxValue = gameObject.GetComponent<AbilityManager>().GetSelectedAbilityList()[1].cooldownCap;
        abilityCooldownSliderObjects[2].GetComponent<Slider>().maxValue = gameObject.GetComponent<AbilityManager>().GetSelectedAbilityList()[2].cooldownCap;
    }
    private void FindAndSetAbilityCooldownTextObjects()
    {
        abilityCooldownTextObjects[0] = GameObject.Find("AbilityOneUI");
        abilityCooldownTextObjects[1] = GameObject.Find("AbilityTwoUI");
        abilityCooldownTextObjects[2] = GameObject.Find("AbilityThreeUI");
    }
    private void SetSlidersToCurrentCooldownRemainder()
    {
        abilityCooldownSliderObjects[0].GetComponent<Slider>().value = gameObject.GetComponent<AbilityManager>().GetSelectedAbilityList()[0].cooldownRemainder;
        abilityCooldownSliderObjects[1].GetComponent<Slider>().value = gameObject.GetComponent<AbilityManager>().GetSelectedAbilityList()[1].cooldownRemainder;
        abilityCooldownSliderObjects[2].GetComponent<Slider>().value = gameObject.GetComponent<AbilityManager>().GetSelectedAbilityList()[2].cooldownRemainder;
    }
    private void SetAbilityCeilingCooldownRemainders()
    {
        CeilingsOfAbilityCooldownRemainders[0] = (int)System.Math.Ceiling(gameObject.GetComponent<AbilityManager>().GetSelectedAbilityList()[0].cooldownRemainder);
        CeilingsOfAbilityCooldownRemainders[1] = (int)System.Math.Ceiling(gameObject.GetComponent<AbilityManager>().GetSelectedAbilityList()[1].cooldownRemainder);
        CeilingsOfAbilityCooldownRemainders[2] = (int)System.Math.Ceiling(gameObject.GetComponent<AbilityManager>().GetSelectedAbilityList()[2].cooldownRemainder);
    }
    private void SetCooldownTextObjectsToCeilingOfCooldownRemainders()
    {
        for (int i = 0; i < 3; i++)
        {
            if (CeilingsOfAbilityCooldownRemainders[i] == 0)
                abilityCooldownTextObjects[i].GetComponent<Text>().text = " ";
            else
                abilityCooldownTextObjects[i].GetComponent<Text>().text = CeilingsOfAbilityCooldownRemainders[i].ToString();
        }
    }
}
