using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySelectUI : MonoBehaviour
{
    [SerializeField]
    GameObject abilityKey0Active;
    [SerializeField]
    GameObject abilityKey1Active;
    [SerializeField]
    GameObject abilityKey2Active;


    [SerializeField]
    GameObject SetAbilityButton0;
    [SerializeField]
    GameObject SetAbilityButton1;
    [SerializeField]
    GameObject SetAbilityButton2;

    int selectedButtonAbilityID;
    private bool toggleStatus = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        abilityKey0Active.GetComponent<Text>().text = PlayerPrefs.GetInt("AbilityKey_0").ToString();
        abilityKey1Active.GetComponent<Text>().text = PlayerPrefs.GetInt("AbilityKey_1").ToString();
        abilityKey2Active.GetComponent<Text>().text = PlayerPrefs.GetInt("AbilityKey_2").ToString();
    }

    public void SetAbilityType(int id)
    {
        selectedButtonAbilityID = id;
        ToggleAbilityButtons();

    }

    public void SetAbilityKey(int key)
    {
        if (key == 0)
        {
            PlayerPrefs.SetInt("AbilityKey_0", selectedButtonAbilityID);
        }
        if (key == 1)
        {
            PlayerPrefs.SetInt("AbilityKey_1", selectedButtonAbilityID);
        }
        if (key == 2)
        {
            PlayerPrefs.SetInt("AbilityKey_2", selectedButtonAbilityID);
        }
        ToggleAbilityButtons();
    }

    private void ToggleAbilityButtons()
    {
        SetAbilityButton0.SetActive(toggleStatus);
        SetAbilityButton1.SetActive(toggleStatus);
        SetAbilityButton2.SetActive(toggleStatus);
        toggleStatus = !toggleStatus;
    }

}
