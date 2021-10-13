using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField]
    GameObject playerHealthUICanvas;
    [SerializeField]
    GameObject playerHealthText;
    [SerializeField]
    GameObject playerNameText;

    GameObject[] players;

    private bool UISetUp = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //players = GameObject.FindGameObjectsWithTag("Player");
        

        // runs first update
        UpdatePlayerList();
        SetUpHealthAndPlayerNameUI();

        // runs every update
        UpdateHealthUI();
    }
    private void UpdatePlayerList()
    {
        int i = 0;
        if (players != null)
        {
            i = players.Length;
        }
        
     
        players = GameObject.FindGameObjectsWithTag("Player");
        
        if (i > players.Length)
            UISetUp = false;
    }
    private void SetUpHealthAndPlayerNameUI()
    {
        if (UISetUp || players.Length == 0)
            return;

        Debug.Log("player count: " + players.Length);
        float heightOffset = 0;
        for (int i = 0; i < players.Length; i++)
        {
            GameObject nameTextObject = Instantiate(playerNameText, playerHealthUICanvas.transform);
            nameTextObject.transform.position += (new Vector3(0, heightOffset));
            heightOffset += 0.5f;

            GameObject healthTextObject = Instantiate(playerHealthText, playerHealthUICanvas.transform);
            healthTextObject.transform.position += (new Vector3(0, heightOffset));
            heightOffset += 0.5f;
            
        }

        UISetUp = true;
    }
    private string GetPlayerName()
    {
        return "Player";
    }
    private void UpdateHealthUI()
    {

    }
}
