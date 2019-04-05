using UnityEngine;
using System.IO.Ports;
using System;
using System.IO;

public class SerialPortControl : MonoBehaviour
{
    private static SerialPortControl instance;
    private static GameObject Contain;

    public SerialPort sp;

    public static SerialPortControl GetInstance()
    {
        if (!instance)
        {
            Contain = new GameObject();
            Contain.name = "SerialPortControl";
            instance = Contain.AddComponent(typeof(SerialPortControl)) as SerialPortControl;
        }
        return instance;

    }

    public void OpenPort(string port, int baud, Parity parity, int bits, StopBits stopbits)
    {
        try
        {
            sp = new SerialPort(port, baud, parity, bits, stopbits);
            sp.ReadTimeout = 200;
            sp.Handshake = Handshake.None;
            sp.ErrorReceived += new SerialErrorReceivedEventHandler(ErrorReceive);
            sp.DtrEnable = true;
            sp.DataReceived += new SerialDataReceivedEventHandler(DataReceive);
            sp.Open();
            Debug.Log("LOCS:: OpenPort :: " + port + " open!");
        }
        catch (Exception ex)
        {
            Debug.Log("LOCS :: " + ex);
        }
    }

    void ErrorReceive(object sender, SerialErrorReceivedEventArgs e)
    {
        Debug.Log("LOCS :: ErrorReceive :: " + e.ToString());
    }

    void DataReceive(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            int bytes = sp.ReadByte();
            Debug.Log(bytes);

        }
        catch (Exception ex)
        {
            Debug.Log("LOCS :: " + ex);
        }
    }

    public void SendData(string data)
    {
        try
        {
            sp.Write(data);


        }
        catch (Exception ex)
        {
            Debug.Log("LOCS :: " + ex);

        }
    }

    
}
