using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonHandler : MonoBehaviour
{
    public GameObject _GameControl;
    public GameObject _Page1;
    public GameObject _Page2;
    public bool PlayGame;
    public bool ConfigureSensitivity;
    public bool Done;
    public bool Light;
    public bool Medium;
    public bool FullExperience;
    
    void ClickButton()
    {
        Debug.Log("button clicked by gun");
        if (PlayGame)
        {
            _GameControl.GetComponent<GameControl>().StartGame();
        }
        else if(ConfigureSensitivity)
        {
            _Page2.SetActive(true);
            _Page1.SetActive(false);
        }
        else if (Done)
        {
            _Page1.SetActive(true);
            _Page2.SetActive(false);
        }
        else if (Light)
        {                                             
            _GameControl.GetComponent<GameControl>().SetSensitivity(1);
            Debug.Log("Light Mode Active");
        }
        else if (Medium)
        {
            _GameControl.GetComponent<GameControl>().SetSensitivity(2);
            Debug.Log("Medium Mode Active");
        }
        else if (FullExperience)
        {
            _GameControl.GetComponent<GameControl>().SetSensitivity(3);
            Debug.Log("Full Mode Active");
        }
    }

   
}
