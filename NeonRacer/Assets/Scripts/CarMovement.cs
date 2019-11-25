using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class CarMovement : MonoBehaviour
{
    public bool playerControlled;
    public GameObject[] points;
    private int[] pNum;
    private NavMeshAgent carAgent;
    private Vector3 moveTest = new Vector3();
    private int nextDestination;
    [SerializeField]
    private float changeDistance;
    private PointManager pointInstance;
    
    void Start()
    {
        pointInstance = FindObjectOfType<PointManager>();
        points = pointInstance.pointHolder;
        carAgent = GetComponent<NavMeshAgent>();

        if (playerControlled == false)
        {
            changeDistance = UnityEngine.Random.Range(0.75f, 3.5f);
            NextPoint();
        }
    }

    void Update()
    {
        if(playerControlled == false)
        {
            ////AI stuff here
            if(!carAgent.pathPending && carAgent.remainingDistance < changeDistance)
            {
                NextPoint();
            }
        }
    }

    public void MoveCar(Vector3 direction)
    {
        carAgent.destination = new Vector3(transform.position.x, 0, transform.position.z);
        carAgent.destination += direction;
    }

    public void NextPoint() // Grab the next point for the AI car to move to
    {
        carAgent.destination = points[nextDestination].transform.position;
        nextDestination = (nextDestination + 1) % points.Length;
    }
}
