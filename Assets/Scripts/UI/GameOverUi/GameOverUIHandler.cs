using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class GameOverUIHandler : NetworkBehaviour
{
    public static bool isGameOverScene = false;
    [SerializeField] GameObject lastGameInterface;
    InterfaceHandler interfaceHandler;
    private bool alreadyInstantiatedInterface = false;
    private void Start()
    {
        interfaceHandler = GameObject.Find("HANDLERS").GetComponent<InterfaceHandler>();
    }
    private void Awake()
    {
    }
    private void Update()
    {
        TryToggleGameOverInterface();
    }
    private void TryToggleGameOverInterface()
    {
        if (isGameOverScene && !alreadyInstantiatedInterface)
        {
            ToggleGameOverInterface();
            alreadyInstantiatedInterface = true;
        }
    }
    public void ToggleGameOverInterface()
    {
        if (isGameOverScene)
        {
            interfaceHandler.AddInterfaceByPrefab(lastGameInterface);
        }
    } 
}
