using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeUIToggle : MonoBehaviour
{
    [SerializeField] InterfaceHandler interfaceHandler;
    [SerializeField] GameObject escapeInterfacePrefab;
    private GameObject escapeInterface;
    private bool isInterfaceActive = false;

    private void Update()
    {
        TryToggleEscapeUI();
    }
    private void TryToggleEscapeUI()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
            return;

        if (interfaceHandler.IsInterfaceActive(escapeInterface))
            DisableEscapeUI();
        else if (interfaceHandler.GetNumberOfActiveInterfaces() == 1)
            EnableEscapeUI();
        else 
            interfaceHandler.RemoveActiveInterface();
    }
    private void EnableEscapeUI()
    {
        escapeInterface = interfaceHandler.AddInterfaceByPrefab(escapeInterfacePrefab);
        isInterfaceActive = !isInterfaceActive;
    }
    private void DisableEscapeUI()
    {
        if (!interfaceHandler.IsInterfaceActive(escapeInterface))
            return;
        interfaceHandler.RemoveActiveInterface();
        isInterfaceActive = !isInterfaceActive;
    }
}
