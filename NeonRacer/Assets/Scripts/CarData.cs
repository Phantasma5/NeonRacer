using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarData : MonoBehaviour
{
    [HideInInspector] public int lapCount = 0;
    [HideInInspector] public CheckPointScript.Checkpoint lastCheckPoint;
    private void Start()
    {
        lastCheckPoint = CheckPointScript.Checkpoint.FinishLine;
    }
}
