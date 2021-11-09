using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySelectToggle : MonoBehaviour
{
    [SerializeField] GameObject interfaceHandler;
    [SerializeField] GameObject interfacePrefab;
    public static bool isInterfaceActive = false;
    static GameObject abilityInterface;

    private void Start()
    {
        interfaceHandler = GameObject.FindGameObjectWithTag("InterfaceHandler");
    }

    public void ToggleAbilityInterface()
    {
        if (!isInterfaceActive)
            CreateAbilitySelectInterface();
        else
            DestroyAbilitySelectInterface();
        isInterfaceActive = !isInterfaceActive;
    }
    private void CreateAbilitySelectInterface()
    {
        abilityInterface = interfaceHandler.GetComponent<InterfaceHandler>().AddInterfaceByPrefab(interfacePrefab);
        Canvas[] canvi = abilityInterface.GetComponentsInChildren<Canvas>();
        foreach (Canvas canvas in canvi)
        {
            canvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        }


    }
    private void DestroyAbilitySelectInterface()
    {
        Destroy(abilityInterface);
        interfaceHandler.GetComponent<InterfaceHandler>().RemoveActiveInterface();
    }
}
