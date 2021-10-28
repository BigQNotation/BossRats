using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAbilityPelletBurst : BossAbility
{

    public GameObject projectilePrefab;

    private const int ID = 2;
    private const float cooldown = 6f;


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

        projectile1.GetComponent<BossAbilityPelletBurstMovement>().AddForce((new Vector2(10f, 0f)).normalized);
        projectile2.GetComponent<BossAbilityPelletBurstMovement>().AddForce((new Vector2(-10f, 0f)).normalized);
        projectile3.GetComponent<BossAbilityPelletBurstMovement>().AddForce((new Vector2(0f, 10f)).normalized);
        projectile4.GetComponent<BossAbilityPelletBurstMovement>().AddForce((new Vector2(0f, -10f)).normalized);
        projectile5.GetComponent<BossAbilityPelletBurstMovement>().AddForce((new Vector2(7.071f, 7.071f)).normalized);
        projectile6.GetComponent<BossAbilityPelletBurstMovement>().AddForce((new Vector2(-7.071f, 7.071f)).normalized);
        projectile7.GetComponent<BossAbilityPelletBurstMovement>().AddForce((new Vector2(7.071f, -7.071f)).normalized);
        projectile8.GetComponent<BossAbilityPelletBurstMovement>().AddForce((new Vector2(-7.071f, -7.071f)).normalized);
    }
}
