using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField]
    GameObject playerHealthUICanvas;
    [SerializeField]
    GameObject playerHealthText;
    [SerializeField]
    GameObject playerNameText;

    GameObject[] players;
    int updatedUIAtPlayerCount = 0;

    [SerializeField] PlayerLoadHandler playerLoadHandler;

    void Start()
    {
    }
    void Update()
    {
        if (!playerLoadHandler.ArePlayersLoaded())
            return;

        UpdatePlayerList();
        TryCreateUI();
        UpdateUIPlayerHealth();
        UpdateUIPlayerNames();
    }
    private void UpdatePlayerList()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
    private void TryCreateUI()
    {
        // Avoid late player connections not being added
        if (updatedUIAtPlayerCount == players.Length)
            return;
        updatedUIAtPlayerCount = players.Length;

        ClearPreviousUI();
        CreateUI();
        SetUIPlayerNames();
    }
    private void ClearPreviousUI()
    {
        int i = 0;
        GameObject[] allChildren = new GameObject[playerHealthUICanvas.transform.childCount];

        foreach (Transform child in playerHealthUICanvas.transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        foreach (GameObject child in allChildren)
        {
            DestroyImmediate(child.gameObject);
        }
    }
    private void CreateUI()
    {
        float heightOffset = 0;
        for (int i = 0; i < players.Length; i++)
        {
            GameObject healthTextObject = Instantiate(playerHealthText, playerHealthUICanvas.transform);
            healthTextObject.transform.position += (new Vector3(0, heightOffset));
            heightOffset += 0.5f;

            GameObject nameTextObject = Instantiate(playerNameText, playerHealthUICanvas.transform);
            nameTextObject.transform.position += (new Vector3(0, heightOffset));
            heightOffset += 0.5f;


        }
    }
    private void SetUIPlayerNames()
    {
        GameObject[] nameTextObjects = GameObject.FindGameObjectsWithTag("PlayerNameText");
        for (int i = 0; i < nameTextObjects.Length; i++)
        {
            nameTextObjects[i].GetComponent<Text>().text = GetPlayerName(i);
            Debug.Log(GetPlayerName(i));
        }
    }
    private string GetPlayerName(int playersIndex)
    {
        return players[playersIndex].GetComponent<PlayerStats>().GetPlayerName();
    }
    private void UpdateUIPlayerHealth()
    {
        GameObject[] healthTextObjects = GameObject.FindGameObjectsWithTag("PlayerHealthText");
        for (int i = 0; i < healthTextObjects.Length; i++)
        {
            healthTextObjects[i].GetComponent<Text>().text = GetPlayerHealth(i); 
        }
    }
    private void UpdateUIPlayerNames()
    {
        GameObject[] nameTextObjects = GameObject.FindGameObjectsWithTag("PlayerNameText");
        for (int i = 0; i < nameTextObjects.Length; i++)
        {
            nameTextObjects[i].GetComponent<Text>().text = GetPlayerName(i);
        }
    }
    private string GetPlayerHealth(int playersIndex)
    {
        return players[playersIndex].GetComponent<PlayerStats>().GetCurrentPlayerHealth().ToString();
    }   
}
