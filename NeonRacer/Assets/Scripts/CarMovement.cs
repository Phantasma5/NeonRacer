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
    private float inputCD;
    

    void Start()
    {
        inputCD = Time.time;
        pointInstance = FindObjectOfType<PointManager>();
        points = pointInstance.pointHolder;
        carAgent = GetComponent<NavMeshAgent>();

        if (playerControlled == false)
        {
            changeDistance = UnityEngine.Random.Range(0.75f, 3.5f);
            carAgent.speed = 2;
            NextPoint();
        }
        else
        {
            carAgent.destination = transform.position;
        }
    }

    void Update()
    {
        if (playerControlled == false)
        {
            ////AI stuff here
            if (!carAgent.pathPending && carAgent.remainingDistance < changeDistance)
            {
                NextPoint();
            }
        }
    }

    public void MoveCar(Vector3 direction)
    {
        carAgent.destination = transform.position;//make it stop

        GameObject temp = new GameObject();
        Vector3 pos = transform.position;
        pos.x += direction.x;
        pos.z += direction.z;
        temp.transform.position = pos;
        carAgent.destination = temp.transform.position;
    }

    public void NextPoint() // Grab the next point for the AI car to move to
    {
        carAgent.destination = points[nextDestination].transform.position;
        nextDestination = (nextDestination + 1) % points.Length;
    }
}
