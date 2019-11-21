using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerDetection : MonoBehaviour
{
    [SerializeField] private List<Text> titleTxt = new List<Text>();
    private void Start()
    {
        string[] joysticks = Input.GetJoystickNames();
        for (int i = 0; i < joysticks.Length; ++i)
        {
            titleTxt[i].text = "Player " + (i + 1) + " Press A to Join!";
            References.controllers.Add(false);
        }
        if (0 == joysticks.Length)
        {
            titleTxt[0].text = "Player " + 1 + " Press Space to Join!";
            References.controllers.Add(false);
        }
    }
    private void Update()
    {
        for (int i = 0; i < References.controllers.Count; ++i)
        {
            if (Input.GetButtonDown("A" + (i + 1)))
            {
                References.controllers[i] = true;
                titleTxt[i].text = "Player " + (i + 1) + " is Ready!";
            }
        }
        if (Input.GetButtonDown("Start"))
        {
            CheckStart();
        }
    }
    private void CheckStart()
    {
        foreach (var item in References.controllers)
        {
            if (item == false)
            {
                return;
            }
        }
        SceneManager.LoadScene("nates scene");
        References.instance.gameObject.GetComponent<SpawnManager>().SpawnCars();
    }
}
