using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class NewBossButton : NetworkBehaviour
{
    [SerializeField] GameObject button;
    LobbySettings lobbySettings;

    public void SwapBoss()
    {
        if (!lobbySettings.server)
            return;

        lobbySettings.newBoss = !lobbySettings.newBoss;
        if (lobbySettings.newBoss)
            PlayerPrefs.SetInt("PlayerDesiresNewBoss", 0);
        else
            PlayerPrefs.SetInt("PlayerDesiresNewBoss", 1);
    }

    private void Start()
    {
        lobbySettings = GameObject.Find("LobbySettings").GetComponent<LobbySettings>();

    }
    private void Update()
    {
        UpdateBossButtonText();
    }
    private void UpdateBossButtonText()
    {
        if (lobbySettings.newBoss)
            button.GetComponentInChildren<Text>().text = "NEW BOSS";
        else
            button.GetComponentInChildren<Text>().text = "PERSEVERE";
    }
}
