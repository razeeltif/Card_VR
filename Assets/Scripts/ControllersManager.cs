using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ControllersManager : MonoBehaviour
{

    static ControllersManager instance = null;

    List<UnityEngine.XR.InputDevice> listDevices;
    List<UnityEngine.XR.InputDevice> listDevicesLeft;
    List<UnityEngine.XR.InputDevice> listDevicesRight;

    InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left;
    InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right;

    public InputDevice leftHand;
    public InputDevice rightHand;


    void Awake()
    {

        if(instance == null)
        {
            instance = this;
        }


        listDevices = new List<UnityEngine.XR.InputDevice>();
        listDevicesLeft = new List<UnityEngine.XR.InputDevice>();
        listDevicesRight = new List<UnityEngine.XR.InputDevice>();

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
        leftHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if(primaryButtonValue)
        {
            Debug.LogWarning("JE SUIS PRESSEEE");
        }
    }


    private void onDeviceConnected(UnityEngine.XR.InputDevice device)
    {
        refreshDevices();
    }

    private void onDeviceDisconnected(UnityEngine.XR.InputDevice device)
    {
        refreshDevices();
    }

    private void refreshDevices()
    {
        UnityEngine.XR.InputDevices.GetDevices(listDevices);

        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, listDevicesLeft);
        if(listDevicesLeft.Count > 0)
        {
            leftHand = listDevicesLeft[0];
        }
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, listDevicesRight);
        if(listDevicesRight.Count > 0)
        {
            rightHand = listDevicesRight[0];
        }
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
