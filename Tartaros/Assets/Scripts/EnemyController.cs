﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{


    public Transform[] destinations;
    public GameObject player;

    private int next = 0;

    private NavMeshAgent agent;

    private Renderer rend;

    private Color dangerColor = Color.red;
    private Color idleColor = Color.white;

    bool idle = true;




    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rend = GetComponent<Renderer>();
        rend.material.color = idleColor;

        agent.destination = (destinations[next].position);
    }



    void Update()
    {

        if (idle)
        {
            agent.speed = 8;
            if (Vector3.Distance(transform.position, agent.destination) < 2f)
            {
                if (next == destinations.Length - 1)
                {
                    next = 0;
                }
                else
                {
                    next++;
                }
                agent.destination = (destinations[next].position);

            }

        }
        else
        {
            agent.speed = 6;
            agent.destination = player.transform.position;

        }

    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("entered");

            idle = false;
            rend.material.color = dangerColor;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            idle = true;
            rend.material.color = idleColor;
        }
    }
}