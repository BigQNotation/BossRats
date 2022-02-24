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
    public GameObject RemoveActiveInterface()
    {
        GameObject removedInterface = openInterfaces[openInterfaces.Count - 1];
        openInterfaces.RemoveAt(openInterfaces.Count - 1);
        EnablePreviousInterfaceInteraction();
        Destroy(removedInterface);
        return removedInterface;
    }

    public bool IsInterfaceActive(GameObject thisInterface)
    {
        return GameObject.Equals(thisInterface, openInterfaces[openInterfaces.Count - 1]);
    }
    public int GetNumberOfActiveInterfaces()
    {
        return openInterfaces.Count;
    }
    public void SwapInterfaces(int index1, int index2)
    {
        openInterfaces[index1].GetComponentInChildren<GraphicRaycaster>().enabled = false;
        openInterfaces[index2].GetComponentInChildren<GraphicRaycaster>().enabled = false;

        GameObject obj1 = openInterfaces[index1];
        GameObject obj2 = openInterfaces[index2];

        openInterfaces[index1] = obj2;
        openInterfaces[index2] = obj1;

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
        if (openInterfaces.Count > 0)
            openInterfaces[openInterfaces.Count - 1].GetComponentInChildren<GraphicRaycaster>().enabled = true;
    }
    
}
