using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class References : MonoBehaviour
{
    public static References instance;
    public GameObject playerOb;
    public List<GameObject> players;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<References>();
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddPlayer() //Add controlable player
    {
        GameObject newPlayer = playerOb;
        newPlayer.GetComponent<CarMovement>().playerControlled = true;
        players.Add(newPlayer);
    }

    public void AddAi() //Add AI controled player
    {
        GameObject newPlayer = playerOb;
        newPlayer.GetComponent<CarMovement>().playerControlled = false;
        players.Add(newPlayer);
    }

    public void SpawnCars()
    {
        for(int i = 0; i < players.Count; i++)
        {
            Instantiate(players[i], new Vector3(i,0), Quaternion.identity);
        }
    }
}
