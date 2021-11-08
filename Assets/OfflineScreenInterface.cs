using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineScreenInterface : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("HANDLERS").GetComponent<InterfaceHandler>().AddInterfaceByObject(gameObject);
    }
}
