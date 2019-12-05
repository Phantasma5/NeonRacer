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
                    if(player.lapCount >= 2)
                    {
                        UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
                        DontDestroyOnLoad(player);
                        Destroy(player.GetComponent<UnityEngine.AI.NavMeshAgent>());
                        Destroy(player.GetComponent<Rigidbody>());
                        Destroy(player.GetComponent<CarMovement>());
                        Destroy(References.instance.gameObject);
                        player.transform.position = Vector3.zero;
                        Vector3 rot = player.transform.eulerAngles;
                        rot.z += 90;
                        player.transform.eulerAngles = rot;
                    }
                }
                break;
            default:
                Debug.Log(sender);
                break;
        }
    }
}
