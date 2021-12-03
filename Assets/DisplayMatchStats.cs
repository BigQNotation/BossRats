using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMatchStats : MonoBehaviour
{
    private void Start()
    {
        foreach (PlayerStatTracker.PlayerStat playerStat in PlayerStatTracker.playerStats)
        {
            gameObject.GetComponent<Text>().text += ("Player " + playerStat.playerID.ToString() + '\n' + playerStat.playerDamageDealt.ToString() + " DMG \n\n");
        }
    }

}
