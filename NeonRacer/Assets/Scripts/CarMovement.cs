using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarMovement : MonoBehaviour
{
    public bool playerControlled;
    public List<GameObject> points = new List<GameObject>();
    private GameObject currentPoint;
    private NavMeshAgent carAgent;
    private Vector3 moveTest = new Vector3();
    private int nextDestination;
    
    void Start()
    {
        carAgent = GetComponent<NavMeshAgent>();
        currentPoint = points[0];
        if(playerControlled == false)
        {
            carAgent.speed = Random.Range(2, 6);
            carAgent.acceleration = Random.Range(1,8);
        }
    }

    void Update()
    {
        if(playerControlled == false)
        {
            ////AI stuff here
            //carAgent.destination = currentPoint.transform.position;
            //if(!carAgent.pathPending && carAgent.remainingDistance < 1)
            //{
            //    NextPoint();
            //}
        }
    }

    public void MoveCar(Vector3 direction)
    {
        carAgent.destination = new Vector3(transform.position.x, 0, transform.position.z);
        carAgent.destination += direction;
    }

    public void NextPoint() // Grab the next point for the AI car to move to
    {
        currentPoint = points[nextDestination];
        nextDestination = (nextDestination + 1) % points.Count;
    }
}
