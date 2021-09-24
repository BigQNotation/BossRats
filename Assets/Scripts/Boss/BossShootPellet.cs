using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossShootPellet : NetworkBehaviour
{
    private float pelletCooldownRemainder = 0;
    private float pelletCooldown = 5f;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isServer)
            return;

        DecrementCooldown();

        if (AbilityReady())
        {

            Shoot();
            ResetCooldown();
        }
    }

    protected void DecrementCooldown()
    {
        pelletCooldownRemainder = Mathf.Max(pelletCooldownRemainder - Time.deltaTime, 0f);
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, gameObject.transform.position, transform.rotation);
        NetworkServer.Spawn(projectile);
    }
    private bool AbilityReady()
    {
        if (pelletCooldownRemainder <= 0)
            return true;
        else
            return false;
    }
    private void ResetCooldown()
    {
        pelletCooldownRemainder = pelletCooldown;
    }
}
