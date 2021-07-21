using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Ability : NetworkBehaviour
{


    protected int abilityID { get; set; }

    public Ability()
    {
        abilityID = -1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetAbilityID()
    {
        return abilityID;
    }
    public virtual void UseAbility()
    {

    }

}
