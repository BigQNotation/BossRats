using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbilityAreaTimeBombActiveExplosion : MonoBehaviour
{
    public GameObject bombZone;
    private float bombDurationTimerCurrent = 3;

    private void Start()
    {
        
    }
    private void Update()
    {
        TryDestroyBombZone();
        UpdateBombDurationTimer();
        TryEndBombEffect();
    }
    private void TryDestroyBombZone()
    {
        if (bombZone != null)
            Destroy(bombZone);
    }
    private void UpdateBombDurationTimer()
    {
        bombDurationTimerCurrent -= Time.deltaTime;
    }
    private void TryEndBombEffect()
    {
        if (bombDurationTimerCurrent <= 0)
            Destroy(gameObject);
    }
}
