using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceOrderDelay : MonoBehaviour
{
    InterfaceHandler interfaceHandler;
    // Start is called before the first frame update
    void Start()
    {
        interfaceHandler = GameObject.Find("HANDLERS").GetComponent<InterfaceHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interfaceHandler.GetNumberOfActiveInterfaces() == 2 && interfaceHandler.IsInterfaceActive(gameObject))
            interfaceHandler.SwapInterfaces(0, 1);
    }
}
