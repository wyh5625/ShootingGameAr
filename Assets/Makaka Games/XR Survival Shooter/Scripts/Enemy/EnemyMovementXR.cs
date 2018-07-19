﻿using UnityEngine;
using System.Collections;

public class EnemyMovementXR : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
    PlayerHealthXR playerHealth;      // Reference to the player's health.
    EnemyHealthXR enemyHealth;        // Reference to this enemy's health.
    UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.


    void Awake ()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealthXR> ();
        enemyHealth = GetComponent <EnemyHealthXR> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
        // If the enemy and the player have health left...
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination (player.position);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            //nav.enabled = false;
        }
    }
}
