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
        if (Input.GetKeyDown(KeyCode.Escape) && !isInterfaceActive)
            EnableEscapeUI();

        else if (Input.GetKeyDown(KeyCode.Escape) && isInterfaceActive)
            DisableEscapeUI();
    }
    private void EnableEscapeUI()
    {
        escapeInterface = interfaceHandler.AddInterfaceByPrefab(escapeInterfacePrefab);
        isInterfaceActive = !isInterfaceActive;
    }
    private void DisableEscapeUI()
    {
        interfaceHandler.RemoveActiveInterface();
        Destroy(escapeInterface);
        isInterfaceActive = !isInterfaceActive;
    }
}
