using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarMovement : MonoBehaviour
{
    public bool playerControlled;
    NavMeshAgent carAgent;
    Vector3 moveTest = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        carAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        moveTest = new Vector3(transform.position.x, 0, transform.position.z);
        if(playerControlled == false)
        {
            //AI stuff here
        }
        moveTest = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        MoveCar(moveTest);
    }

    public void MoveCar(Vector3 direction)
    {
        carAgent.destination += direction;
    }
}
