using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankUI : MonoBehaviour
{
    public GameObject[] PlayerObjects;
    GameObject player;
    public TextMeshProUGUI laps;
    public TextMeshProUGUI rank;

    private void Start()
    {
        PlayerObjects = GameObject.FindGameObjectsWithTag("Player");


        foreach (GameObject p in PlayerObjects)
        {
            if (p.name == "PlayerPrefab" && name == "PlayersUI (3)")
            {
                player = p;
            }
            else if (p.name == "PlayerPrefab (1)" && name == "PlayersUI")
            {
                player = p;
            }
            else if (p.name == "PlayerPrefab (2)" && name == "PlayersUI (2)")
            {
                player = p;
            }
            else if (p.name == "PlayerPrefab (3)" && name == "PlayersUI (1)")
            {
                player = p;
            }
        }

    }

    private void Update()
    {
        laps.text = "Lap " + player.GetComponent<CarData>().lapCount + "/" + "3";

        rank.text = player.GetComponent<CarData>().rank.ToString();
    }
}
