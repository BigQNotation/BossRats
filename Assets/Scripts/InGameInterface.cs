using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameInterface : MonoBehaviour
{
    public bool backToRoom = false;
    public bool onlyChangeOnce = true;
    private void Start()
    {
        GameObject.Find("HANDLERS").GetComponent<InterfaceHandler>().AddInterfaceByObject(gameObject);
    }
    public void ButtonBackToRoom()
    {
        backToRoom = true;
    }

}

