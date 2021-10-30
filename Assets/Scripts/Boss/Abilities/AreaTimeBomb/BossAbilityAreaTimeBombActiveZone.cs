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

    // Start is called before the first frame update
    void Start()
    {
        bombTimerCurrent = bombTimerMax;
    }

    // Update is called once per frame
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
        if (bombTimerCurrent <= 0)
        {
            GameObject bombExplosion = Instantiate(bombExplosionPrefab, explosionLocation, transform.rotation);
            bombExplosion.GetComponent<BossAbilityAreaTimeBombActiveExplosion>().bombZone = gameObject;
        }
    }
}
