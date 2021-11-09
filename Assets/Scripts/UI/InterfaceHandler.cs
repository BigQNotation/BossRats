using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceHandler : MonoBehaviour
{
    List<GameObject> openInterfaces = new List<GameObject>();

    public GameObject AddInterfaceByPrefab(GameObject interfacePrefab)
    {
        GameObject newInterface = Instantiate(interfacePrefab);
        openInterfaces.Add(newInterface);
        DisablePreviousInterfaceInteraction();
        return newInterface;
    }
    public void AddInterfaceByObject(GameObject interfaceObject)
    {
        openInterfaces.Add(interfaceObject);
        DisablePreviousInterfaceInteraction();
    }
    public void RemoveActiveInterface()
    {
        openInterfaces.RemoveAt(openInterfaces.Count - 1);
        EnablePreviousInterfaceInteraction();
    }

    private void DisablePreviousInterfaceInteraction()
    {
        if (openInterfaces.Count == 1)
            return;

        openInterfaces[openInterfaces.Count - 2].GetComponentInChildren<GraphicRaycaster>().enabled = false;
    }
    private void EnablePreviousInterfaceInteraction()
    {
        openInterfaces[openInterfaces.Count - 1].GetComponentInChildren<GraphicRaycaster>().enabled = true;
    }
}
