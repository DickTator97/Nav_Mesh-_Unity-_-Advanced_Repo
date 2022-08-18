using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class CharacterMover : MonoBehaviour
{
    public Transform[] targetDestinations;
    public NavMeshAgent navMeshAgent;

    public float minDistanceForNextWaypoint;

    public bool looping = false;

    bool finishedRoute = false;
    int currentWaypointIndex = 0;

    //private void Start()
    //{
    //    GoToNextWaypoint();
    //}

    private void Update()
    {
        if (!finishedRoute)
        {
            if (navMeshAgent.remainingDistance <= minDistanceForNextWaypoint)
            {
                GoToNextWaypoint();
            }
        }
    }
    void GoToNextWaypoint()
    {
        navMeshAgent.SetDestination(targetDestinations[currentWaypointIndex].position);
        currentWaypointIndex++;
        if (currentWaypointIndex >= targetDestinations.Length)
        {
            if (looping)
                currentWaypointIndex = 0;
            else
                finishedRoute = true;
        }
    }
}
