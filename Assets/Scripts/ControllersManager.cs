using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ControllersManager : MonoBehaviour
{

    List<UnityEngine.XR.InputDevice> listDevices;


    void Awake()
    {
        listDevices = new List<UnityEngine.XR.InputDevice>();

        InputDevices.deviceConnected += onDeviceConnected;
        InputDevices.deviceDisconnected += onDeviceDisconnected;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void onDeviceConnected(UnityEngine.XR.InputDevice device)
    {
        UnityEngine.XR.InputDevices.GetDevices(listDevices);
        logAllDevices();

    }

    private void onDeviceDisconnected(UnityEngine.XR.InputDevice device)
    {
        UnityEngine.XR.InputDevices.GetDevices(listDevices);
        logAllDevices();
    }


    private void logAllDevices()
    {
        foreach (var device in listDevices)
        {
            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.role.ToString()));
        }        
    }
}
