using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField]
    GameObject[] playerObjects;
    public void AddPlayer(bool aHuman) //Add controlable player
    {
        GameObject newPlayer = Instantiate(playerPrefab);
        newPlayer.GetComponent<CarMovement>().playerControlled = aHuman;
        References.players.Add(newPlayer);
    }

    public void SpawnCars()
    {
        StartCoroutine(SpawnCarsCoroutine());
    }
    IEnumerator SpawnCarsCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        //for(int i = 0; i < 4; ++i)
        //{
        //    if(i < References.controllers.Count)
        //    {
        //        AddPlayer(true);
        //    }
        //    else
        //    {
        //        AddPlayer(false);
        //    }
        //}
        playerObjects = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < References.controllers.Count; i++)
        {
            playerObjects[i].GetComponent<CarMovement>().playerControlled = true;
            References.players.Add(playerObjects[i]);
        }
        for (int i = 0; i < 4; ++i)
        {
            References.players[i].transform.position = new Vector3(i*2, 0, 0);
            switch(i)
            {
                case 0:
                    References.players[i].GetComponentInChildren<Renderer>().material.color = Color.red;
                    References.players[i].GetComponentInChildren<TrailRenderer>().material.color = Color.red;
                    References.players[i].GetComponentInChildren<TrailRenderer>().startColor = Color.red;
                    References.players[i].GetComponentInChildren<TrailRenderer>().endColor = Color.red;
                    break;
                case 1:
                    References.players[i].GetComponentInChildren<Renderer>().material.color = Color.blue;
                    References.players[i].GetComponentInChildren<TrailRenderer>().material.color = Color.blue;
                    References.players[i].GetComponentInChildren<TrailRenderer>().startColor = Color.blue;
                    References.players[i].GetComponentInChildren<TrailRenderer>().endColor = Color.blue;

                    break;
                case 2:
                    References.players[i].GetComponentInChildren<Renderer>().material.color = new Color(0,1,1);
                    References.players[i].GetComponentInChildren<TrailRenderer>().material.color = new Color(0, 1, 1);
                    References.players[i].GetComponentInChildren<TrailRenderer>().startColor = new Color(0, 1, 1);
                    References.players[i].GetComponentInChildren<TrailRenderer>().endColor = new Color(0, 1, 1);
                    break;
                case 3:
                    References.players[i].GetComponentInChildren<Renderer>().material.color = new Color(0.5f,0,1);
                    References.players[i].GetComponentInChildren<TrailRenderer>().material.color = new Color(0.5f, 0, 1);
                    References.players[i].GetComponentInChildren<TrailRenderer>().startColor = new Color(0.5f, 0, 1);
                    References.players[i].GetComponentInChildren<TrailRenderer>().endColor = new Color(0.5f, 0, 1);
                    break;
            }
        }
    }
}
