using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    public enum Checkpoint
    {
        First,
        CheckPoint1,
        CheckPoint2,
        FinishLine,
        Last
    }
    [SerializeField] private Checkpoint myCheckpoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CheckpointReached(other.GetComponent<CarData>(), myCheckpoint);
        }
    }
    public void CheckpointReached(CarData player, Checkpoint sender)
    {
        switch (sender)
        {
            case Checkpoint.CheckPoint1:
                if (Checkpoint.FinishLine == player.lastCheckPoint)
                {
                    player.lastCheckPoint = sender;
                }
                break;
            case Checkpoint.CheckPoint2:
                if (Checkpoint.CheckPoint1 == player.lastCheckPoint)
                {
                    player.lastCheckPoint = sender;
                }
                break;
            case Checkpoint.FinishLine:
                if (Checkpoint.CheckPoint2 == player.lastCheckPoint)
                {
                    player.lastCheckPoint = sender;
                    player.lapCount++;
                }
                break;
            default:
                Debug.Log(sender);
                break;
        }
    }
}
