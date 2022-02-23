using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbarUI : MonoBehaviour
{
    [SerializeField] GameObject healthBarPrefab;
    GameObject healthBarObject;

    void Start()
    {
        SpawnPlayerHealthBar();
    }
    void Update()
    {
        ScaleBarToHealth();
    }
    void LateUpdate()
    {
        UpdatePlayerHealthBarPosition();
    }
    private void SpawnPlayerHealthBar()
    {
        healthBarObject = GameObject.Instantiate(healthBarPrefab);
        healthBarObject.GetComponentInChildren<Slider>().maxValue = gameObject.GetComponent<PlayerStats>().GetMaxPlayerHealth();
    }
    private void UpdatePlayerHealthBarPosition()
    {
        healthBarObject.transform.position = gameObject.transform.position;
    }
    private void ScaleBarToHealth()
    {
        healthBarObject.GetComponentInChildren<Slider>().value = gameObject.GetComponent<PlayerStats>().GetCurrentPlayerHealth();
    }
}
