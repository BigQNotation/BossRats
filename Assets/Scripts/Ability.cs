using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Ability : NetworkBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileMount;
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void UseAbility(int abilityKey)
    {

        Debug.Log(abilityKey);
        GameObject projectile = Instantiate(projectilePrefab, projectileMount.position, transform.rotation);
        NetworkServer.Spawn(projectile);
    }

}
