using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    List<GameObject> gameManager = new List<GameObject>(); //When the game manager is in change this to that

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = FindObjectOfType(GameManager)
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < gameManager.Count; i++)
        {
            if(gameObject == gameManager[i])
            {
                //Playermovement script  Input.GetAxis horizontal + i
                gameManager[i].GetComponent<CarMovement>().MoveCar(new Vector3(Input.GetAxis("Horizontal " + i), Input.GetAxis("Vertical " + i)));
            }
        }
    }
}
