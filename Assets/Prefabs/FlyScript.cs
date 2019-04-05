using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : MonoBehaviour
{
    public Camera cam;
    public float speed;
    float x;
    float z;
    float y;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            z += speed;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            z -= speed;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            x -= speed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            x += speed;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            y += speed;
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            y -= speed;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            z = 0 ;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            z = 0;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            x = 0;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            x = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            y = 0;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            y = 0;
        }


        float facingx = cam.transform.eulerAngles.x;
        float facingy = cam.transform.eulerAngles.y;
        float facingz = cam.transform.eulerAngles.z;
        Vector3 myInputs = new Vector3(x, y, z);
        Vector3 movement = Quaternion.Euler(facingx, facingy, 0) * myInputs;
        transform.position += movement;
     //   print(new Vector3(x, y, z));
     
    }
}
