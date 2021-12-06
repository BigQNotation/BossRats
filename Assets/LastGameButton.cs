using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastGameButton : MonoBehaviour
{
    
    private void Update()
    {
        if (PlayerStatTracker.playerStats.Count == 0)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
            gameObject.GetComponent<Button>().interactable = true;
    }
}
