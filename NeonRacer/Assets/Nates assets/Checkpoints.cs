using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public GameObject[] Points;
    public GameObject[] Players;
    GameObject currentCheckpoint;

    [SerializeField]
    int numPoints;

    private void Start()
    {
        Points = new GameObject[numPoints];
    }

    private void Update()
    {
        foreach (GameObject p in Players)
        {

        }
    }
}
