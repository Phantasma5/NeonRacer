using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarMovement : MonoBehaviour
{
    public bool playerControlled;
    public List<GameObject> points = new List<GameObject>();
    GameObject currentPoint;
    NavMeshAgent carAgent;
    Vector3 moveTest = new Vector3();
    int nextDestination;
    
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if(playerControlled == false)
        {
            //AI stuff here
            carAgent.destination = currentPoint.transform.position;
            if(!carAgent.pathPending && carAgent.remainingDistance < 1)
            {
                NextPoint();
            }
        }
        else
        {
            moveTest = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            MoveCar(moveTest);
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
