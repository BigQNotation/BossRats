using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAbilityPelletBurst : BossAbility
{

    public GameObject projectilePrefab;

    private const int ID = 2;
    private const float cooldown = 6f;

    public Vector2 velocity = new Vector2(0.0f, 0.0f);

    public BossAbilityPelletBurst()
    {
        this.abilityID = ID;
        this.COOLDOWN = cooldown;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isServer)
            return;


    }


    public override void UseAbility()
    {
        GameObject projectile1 = Instantiate(projectilePrefab, gameObject.transform.position, transform.rotation);
        GameObject projectile2 = Instantiate(projectilePrefab, gameObject.transform.position, transform.rotation);
        GameObject projectile3 = Instantiate(projectilePrefab, gameObject.transform.position, transform.rotation);
        GameObject projectile4 = Instantiate(projectilePrefab, gameObject.transform.position, transform.rotation);
        GameObject projectile5 = Instantiate(projectilePrefab, gameObject.transform.position, transform.rotation);
        GameObject projectile6 = Instantiate(projectilePrefab, gameObject.transform.position, transform.rotation);
        GameObject projectile7 = Instantiate(projectilePrefab, gameObject.transform.position, transform.rotation);
        GameObject projectile8 = Instantiate(projectilePrefab, gameObject.transform.position, transform.rotation);

        projectile1.GetComponent<PelletMovement>().velocity = (new Vector2(10f,0f));
        projectile2.GetComponent<PelletMovement>().velocity = (new Vector2(-10f, 0f));
        projectile3.GetComponent<PelletMovement>().velocity = (new Vector2(0f, 10f));
        projectile4.GetComponent<PelletMovement>().velocity = (new Vector2(0f, -10f));
        projectile5.GetComponent<PelletMovement>().velocity = (new Vector2(7.071f, 7.071f));
        projectile6.GetComponent<PelletMovement>().velocity = (new Vector2(-7.071f, 7.071f));
        projectile7.GetComponent<PelletMovement>().velocity = (new Vector2(7.071f, -7.071f));
        projectile8.GetComponent<PelletMovement>().velocity = (new Vector2(-7.071f, -7.071f));

        NetworkServer.Spawn(projectile1);
        NetworkServer.Spawn(projectile2);
        NetworkServer.Spawn(projectile3);
        NetworkServer.Spawn(projectile4);
        NetworkServer.Spawn(projectile5);
        NetworkServer.Spawn(projectile6);
        NetworkServer.Spawn(projectile7);
        NetworkServer.Spawn(projectile8);
    }
}
