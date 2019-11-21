using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarMovement : MonoBehaviour
{
    public bool playerControlled;
    public GameObject[] points;
    private NavMeshAgent carAgent;
    private Vector3 moveTest = new Vector3();
    private int nextDestination;
    [SerializeField]
    private float changeDistance;
    
    void Start()
    {
        
        points = GameObject.FindGameObjectsWithTag("Point");
        carAgent = GetComponent<NavMeshAgent>();

        //nextDestination = 0;
        if (playerControlled == false)
        {
            //carAgent.speed = 50;
            //carAgent.acceleration = 50;
            changeDistance = Random.Range(0.5f, 3.5f);
            NextPoint();
        }
    }

    void Update()
    {
        if(playerControlled == false)
        {
            ////AI stuff here
            //carAgent.destination = points[nextDestination].transform.position;
            
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
        Debug.Log(carAgent.destination);
        nextDestination = (nextDestination + 1) % points.Length;
    }
}
