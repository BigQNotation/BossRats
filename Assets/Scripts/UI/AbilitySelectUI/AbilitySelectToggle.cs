using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySelectToggle : MonoBehaviour
{
    [SerializeField] GameObject interfaceHandler;
    [SerializeField] GameObject interfacePrefab;
    public static bool isInterfaceActive = false;
    static GameObject abilityInterface;
    public void CreateAbilitySelectInterface()
    {
        abilityInterface = interfaceHandler.GetComponent<InterfaceHandler>().AddInterfaceByPrefab(interfacePrefab);
        Canvas[] canvi = abilityInterface.GetComponentsInChildren<Canvas>();
        foreach (Canvas canvas in canvi)
        {
            canvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        }
    }
    public void DestroyAbilitySelectInterface()
    {
        interfaceHandler.GetComponent<InterfaceHandler>().RemoveActiveInterface();
    }

    private void Start()
    {
        interfaceHandler = GameObject.FindGameObjectWithTag("InterfaceHandler");
    }

}
