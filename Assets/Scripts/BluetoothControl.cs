using UnityEngine;
using System;

/// <summary>
/// json data
/// </summary>
[Serializable]
public class JsonData
{
    public string damageLevel;
}


public class BluetoothControl : MonoBehaviour
{
    //You need to confirm the COMPort first!
    string COMPort = "COM6";
    

    // Use this for initialization
    void Start()
    {
#if UNITY_EDITOR|| UNITY_STANDALONE

        string portName = @"\\.\" + COMPort;
        SerialPortControl.GetInstance().OpenPort(portName, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
#endif
    }
    
    /// <summary>
    /// Send Bluetooth data
    /// </summary>
    /// <param name="str"></param>
    public void SendData(JsonData data)
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        SerialPortControl.GetInstance().SendData(JsonUtility.ToJson(data));
#endif
    }
}


