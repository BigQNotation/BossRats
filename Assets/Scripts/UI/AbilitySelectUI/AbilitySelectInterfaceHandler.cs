using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class AbilitySelectInterfaceHandler : MonoBehaviour
{
    [SerializeField] GameObject abilitySelectCanvas;
    public static bool isAbilitySelectInterfaceOpen = false;
    public AbilitySelectInterfaceHandler()
    {
        isAbilitySelectInterfaceOpen = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleAbilitySelectInterface(bool toggleInterface)
    {
        if (toggleInterface)
        {
            abilitySelectCanvas.SetActive(true);
            isAbilitySelectInterfaceOpen = true;
        }
        else
        {
            isAbilitySelectInterfaceOpen = false;
            abilitySelectCanvas.SetActive(false);
        }
            
    }
}
