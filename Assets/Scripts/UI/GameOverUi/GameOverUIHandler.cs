using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class GameOverUIHandler : NetworkBehaviour
{
    /* NOTE that if isGameOverScene 
     * is used for logical comparisons 
     * outside of GameOverUIHandler,
     * the logic should be opposite
     * due to isGameOverScene being flipped
     * during its toggle into the game
     * over scene.
     */
    public static bool isGameOverScene = false;
    [SerializeField] GameObject gameOverCanvas;

    private void Start()
    {
   
    }
    private void Awake()
    {
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

        isGameOverScene = !isGameOverScene;
    } 
}
