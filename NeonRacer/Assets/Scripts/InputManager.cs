using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    List<GameObject> gameManager = new List<GameObject>(); //When the game manager is in change this to that
    References refInstance;

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = FindObjectOfType(GameManager)
        refInstance = FindObjectOfType<References>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < refInstance.players.Count; i++)
        {
            if(gameObject == refInstance.players[i])
            {
                refInstance.players[i].GetComponent<CarMovement>().MoveCar(new Vector3(Input.GetAxis("Horizontal " + i), Input.GetAxis("Vertical " + i)));
            }
        }
    }
}
