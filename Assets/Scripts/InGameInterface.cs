using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameInterface : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("HANDLERS").GetComponent<InterfaceHandler>().AddInterfaceByObject(gameObject);
    }
}

