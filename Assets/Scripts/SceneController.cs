using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadAbilityScene()
    {
        GameObject roomManager = GameObject.Find("RoomManager");
        roomManager.GetComponent<NetworkManagerHUD>().showGUI = false;
        SceneManager.LoadScene("AbilitySelectScene");
    }
    public void LoadOfflineScene()
    {
        GameObject roomManager = GameObject.Find("RoomManager");
        roomManager.GetComponent<NetworkManagerHUD>().showGUI = true;
        SceneManager.LoadScene("OfflineScene");
    }
}
