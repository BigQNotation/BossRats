using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class NewBossButton : NetworkBehaviour
{
    [SerializeField] GameObject button;
    static bool wantsNewBoss = false;
    private void Start()
    {
        if (!isServer)
        {
            button.SetActive(false);
        }
        if (wantsNewBoss)
            PlayerPrefs.SetInt("PlayerDesiresNewBoss", 0);
        else
            PlayerPrefs.SetInt("PlayerDesiresNewBoss", 1);
    }

    private void Update()
    {
        if (wantsNewBoss)
            button.GetComponentInChildren<Text>().text = "NEW BOSS";
        else
            button.GetComponentInChildren<Text>().text = "PERSEVERE";
    }

    public void SwapBoss()
    {
        wantsNewBoss = !wantsNewBoss;
        if (wantsNewBoss)
            PlayerPrefs.SetInt("PlayerDesiresNewBoss", 0);
        else
            PlayerPrefs.SetInt("PlayerDesiresNewBoss", 1);
        
    }

}
