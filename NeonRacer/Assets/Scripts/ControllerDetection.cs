using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerDetection : MonoBehaviour
{
    [HideInInspector] private List<bool> controllers = new List<bool>();
    [SerializeField] private List<Text> titleTxt = new List<Text>();
    References refInstance;
    private void Start()
    {
        refInstance = FindObjectOfType<References>();
        string[] joysticks = Input.GetJoystickNames();
        Debug.Log(joysticks.Length);
        for (int i = 0; i < joysticks.Length; ++i)
        {
            titleTxt[i].text = "Player " + (i+1) + " Press A to Join!";
            controllers.Add(false);
        }
    }
    private void Update()
    {
        for (int i = 0; i < controllers.Count; ++i)
        {
            if (Input.GetButtonDown("A" + (i+1)))
            {
                controllers[i] = true;
                titleTxt[i].text = "Player " + (i+1) + " is Ready!";
                refInstance.players.Add(new GameObject()); //Add a new car to the list
            }
        }
        if(Input.GetButtonDown("Start"))
        {
            CheckStart();
        }
    }
    private void CheckStart()
    {
        foreach (var item in controllers)
        {
            if (item == false)
            {
                return;
            }
        }
        SceneManager.LoadScene("SampleScene");
    }
}
