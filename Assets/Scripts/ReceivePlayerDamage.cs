using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivePlayerDamage : MonoBehaviour {

    public ShowPlayerPain showPlayerPain;
    BluetoothControl bluetoothControl;
    int UserChoiceCoeff;
    // Use this for initialization
    void Start () {

		bluetoothControl = GameObject.Find("BluetoothControl").GetComponent<BluetoothControl>();
		
	}
	
    void SetUserChoiceCoeff(string choice)
    {
        if(choice == "Light")
        {
            UserChoiceCoeff = 1;
        }
        else if(choice == "Medium")
        {
            UserChoiceCoeff = 3;
        }
        else if (choice == "Full")
        {
            UserChoiceCoeff = 5;
        }
    }

    public void Damage (int damageAmount)
    {
        int finalDamage = UserChoiceCoeff;
        Debug.Log("player takes " + finalDamage);
        showPlayerPain.AddPain();

        //If int damageAmount is a set damage level
        JsonData data = new JsonData();
        data.damageLevel = finalDamage.ToString();
        bluetoothControl.SendData(data);


    }
}
