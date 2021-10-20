using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class GameOverUIHandler : NetworkBehaviour
{
    public static bool isGameOverScene = false;
    [SerializeField] GameObject gameOverCanvas;

    private void Start()
    {
   
    }
    private void Awake()
    {
        ToggleGameOverInterface();
    }

    public void BackToLobbyToggleInterfaceOff()
    {
        isGameOverScene = false;
        ToggleGameOverInterface();
    }
    public void ToggleGameOverInterface()
    {
        if (isGameOverScene)
        {
            GameObject.Find("RoomManager").GetComponent<NetworkManagerHUD>().showGUI = false;
            gameOverCanvas.SetActive(true);
        }
        else
        {
            GameObject.Find("RoomManager").GetComponent<NetworkManagerHUD>().showGUI = true;
            gameOverCanvas.SetActive(false);
        }

        
    } 
}
