using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SplineMesh;

public class Placements : MonoBehaviour
{
    public Spline spline;
    public GameObject[] PlayerObjects;
    float sampleDistance;
    public List<GameObject> Players = new List<GameObject>(); 

    private void Start()
    {
        PlayerObjects = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject g in PlayerObjects)
        {
            Players.Add(g);
        }
    }

    private void Update()
    {
        foreach (GameObject g in Players)
        {
            g.GetComponent<CarData>().minDistance = float.PositiveInfinity;
        }

        for (float sampleDistance = 0; sampleDistance < spline.Length; sampleDistance += 1)
        {
            Vector3 sample = spline.GetSampleAtDistance(sampleDistance).location;
            foreach (var player in Players)
            {
                float dist = Vector3.Distance(sample, player.transform.position);
                if (dist < player.gameObject.GetComponent<CarData>().minDistance)
                {
                    player.gameObject.GetComponent<CarData>().minDistance = dist;
                    player.gameObject.GetComponent<CarData>().distAlongSpline = sampleDistance;
                }
            }
        }

         // TODO: sort players by checkpoints and laps 

        Players.Sort(SortByDist);
        Players.Reverse();

        //set rank on player
        for (int i = 1; i < Players.Count + 1; i++)
        {
            Players[i-1].GetComponent<CarData>().rank = i;
        }

        // Dubug to show the car placements
        foreach (GameObject g in Players)
        {
            Debug.Log(g.name + " " + g.GetComponent<CarData>().distAlongSpline);
        }
    }

    static int SortByDist(GameObject p1, GameObject p2)
    {
        return p1.GetComponent<CarData>().distAlongSpline.CompareTo(p2.GetComponent<CarData>().distAlongSpline);
    }
}
