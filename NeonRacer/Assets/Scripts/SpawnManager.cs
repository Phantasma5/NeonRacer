using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
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
        yield return new WaitForSeconds(2);
        for(int i = 0; i < 4; ++i)
        {
            if(i < References.controllers.Count)
            {
                AddPlayer(true);
            }
            else
            {
                AddPlayer(false);
            }
        }
        for(int i = 0; i < 4; ++i)
        {
            References.players[i].transform.position = new Vector3(i*2, 9.4f, -40);
        }
    }
}
