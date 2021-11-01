using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbilityAreaTimeBombActiveZone : MonoBehaviour
{
    public GameObject bombExplosionPrefab;

    private float bombTimerCurrent;
    private float bombTimerMax = 5f;
    public Vector3 explosionLocation;
    public GameObject timeBombZone;
    private bool bombCreated = false;

    void Start()
    {
        bombTimerCurrent = bombTimerMax;
    }

    void Update()
    {
        UpdateBombTimer();
        TryExplodeBomb();
    }
    private void UpdateBombTimer()
    {
        bombTimerCurrent -= Time.deltaTime;
    }
    private void TryExplodeBomb()
    {
        if (bombTimerCurrent <= 0 && !bombCreated)
        {
            GameObject bombExplosion = Instantiate(bombExplosionPrefab, explosionLocation, transform.rotation);
            bombExplosion.GetComponent<BossAbilityAreaTimeBombActiveExplosion>().bombZone = gameObject;
            bombCreated = true;
        }
    }
}
