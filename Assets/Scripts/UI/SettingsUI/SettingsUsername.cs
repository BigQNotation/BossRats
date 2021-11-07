using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUsername : MonoBehaviour
{
    [SerializeField] GameObject usernameText;
    private int currentLength;
    private void Start()
    {
        PlayerPrefs.GetString("Username", "New Rat");
    }

    public void ChangeUsernameButton()
    {
        PlayerPrefs.SetString("Username", usernameText.GetComponent<Text>().text);
        Debug.Log("Player username updated to " + PlayerPrefs.GetString("Username"));
    }


}
