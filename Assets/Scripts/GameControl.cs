using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public LayerMask layermask;
    public GameObject _Menu;
    public bool isMenuOpen = true;
    public Transform L_UserGun;
    public Transform R_UserGun;
    public GameObject _Spawner;
    //GameObject[] soldiers;

    /*
    public void OpenMenu()
    {
        if (isMenuOpen)
        {
            PauseGame(false);
            _Menu.SetActive(false);
            isMenuOpen = false;
        }
        else
        {
            PauseGame(true);
            _Menu.SetActive(true);
            isMenuOpen = true;
        }
    }
    */

    public void SetSensitivity(int value)
    {
       var sense = value;
        print("Sensitivity Choice is " + sense);
        //set shock quality relative to valueChanged
    }

    public void StartGame()
    {
        print("gameStarted");
        _Menu.SetActive(false);
        isMenuOpen = false;
        _Spawner.SetActive(true);
    }
    
   

    public void L_GunMenuFire()
    {
        //ShootNow() will happen for the visual effect.
        //this logic will navigate the menu
        if(isMenuOpen)
        {
            print("lgunFired");
            RaycastHit hit;
            if (Physics.Raycast(L_UserGun.position, L_UserGun.TransformDirection(Vector3.forward), out hit, 1000, layermask))
            {
                Debug.Log("L Gun hit = " + hit.transform.gameObject.name);
                hit.collider.SendMessage("ClickButton");
            }
        }
    }

    public void R_GunMenuFire()
    {
        //ShootNow() will happen for the visual effect.
        //this logic will navigate the menu
        if (isMenuOpen)
        {
            print("RgunFired");
            RaycastHit hit;
            if (Physics.Raycast(R_UserGun.position, R_UserGun.TransformDirection(Vector3.forward), out hit, 1000))
            {
                Debug.Log("R_Gun hit = " + hit.transform.gameObject.name);
                hit.collider.SendMessage("ClickButton");
            }
        }
    }







}
