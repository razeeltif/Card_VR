using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{

        public delegate void test();
        public static test onConnect;


    private InputDevice targetDevice;
    List<UnityEngine.XR.InputDevice> inputDevices;
    // Start is called before the first frame update
    void Start()
    {


        InputDevices.deviceConnected += Action_performed;

    }

    // Update is called once per frame
    void Update()
    {

    UnityEngine.XR.InputDevices.GetDevices(inputDevices);
    InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right, inputDevices);



    targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
    if(primaryButtonValue)
    {
        Debug.Log("ZAZERTGAZGEAZERGZEAR");
    }

     /*   UnityEngine.XR.InputDevices.GetDevices(inputDevices);

        foreach (var device in inputDevices)
        {
            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.role.ToString()));
        }*/
    }

    private void Action_performed(UnityEngine.XR.InputDevice obj)
    {
        Debug.Log("Select Button is pressed");
    }

}
