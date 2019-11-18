using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class References : MonoBehaviour
{
    public static References instance;
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
}
