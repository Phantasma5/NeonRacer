using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        for(int i = 0; i < References.players.Count; i++)
        {
            if(gameObject == References.players[i])
            {
                References.players[i].GetComponent<CarMovement>().MoveCar(new Vector3(Input.GetAxis("Horizontal " + i), 0, Input.GetAxis("Vertical " + i)));
            }
        }
    }
}
