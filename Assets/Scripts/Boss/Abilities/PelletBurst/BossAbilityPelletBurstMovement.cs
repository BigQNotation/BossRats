﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbilityPelletBurstMovement : MonoBehaviour
{
    public Vector2 velocity = new Vector2(0.0f, 0.0f);

    void Start()
    {

    }

    void Update()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 newPosition = currentPosition + velocity * Time.deltaTime;

        transform.position = newPosition;
    }
}
