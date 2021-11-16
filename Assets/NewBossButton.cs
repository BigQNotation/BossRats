using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class NewBossButton : NetworkBehaviour
{
    [SerializeField] GameObject button;
    LobbySettings lobbySettings;
    static bool wantsNewBoss = false;
    private void Start()
    {
        lobbySettings = GameObject.Find("LobbySettings").GetComponent<LobbySettings>();
        if (!lobbySettings.server)
            return;
        if (wantsNewBoss)
            PlayerPrefs.SetInt("PlayerDesiresNewBoss", 0);
        else
            PlayerPrefs.SetInt("PlayerDesiresNewBoss", 1);
    }

    private void Update()
    {
        if (!lobbySettings.server)
            return;

        if (wantsNewBoss)
            button.GetComponentInChildren<Text>().text = "NEW BOSS";
        else
            button.GetComponentInChildren<Text>().text = "PERSEVERE";
    }

    public void SwapBoss()
    {
        if (!lobbySettings.server)
            return;

        wantsNewBoss = !wantsNewBoss;
        if (wantsNewBoss)
            PlayerPrefs.SetInt("PlayerDesiresNewBoss", 0);
        else
            PlayerPrefs.SetInt("PlayerDesiresNewBoss", 1);
        
    }

}
