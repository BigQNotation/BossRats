using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCurrentInterface : MonoBehaviour
{
    InterfaceHandler interfaceHandler;
    // Start is called before the first frame update
    void Start()
    {
        interfaceHandler = GameObject.Find("HANDLERS").GetComponent<InterfaceHandler>();
    }

    public void RemoveInterface()
    {
        interfaceHandler.RemoveActiveInterface();
    }
}
