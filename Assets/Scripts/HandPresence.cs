using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{

    public InputDeviceCharacteristics controllerCharacteristics;
    public GameObject handModelPrefab;

    //public List<GameObject> controllerPrefabs;

    static ControllersManager instance = null;

    List<UnityEngine.XR.InputDevice> listDevices;

    private InputDevice targetDevice;
    private GameObject spawnedHandModel;


    void Awake()
    {

        listDevices = new List<UnityEngine.XR.InputDevice>();

      /*  InputDevices.deviceConnected += onDeviceConnected;
        InputDevices.deviceDisconnected += onDeviceDisconnected;*/
    }


    // Start is called before the first frame update
    void Start()
    {

        refreshDevices();

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void onDeviceConnected(UnityEngine.XR.InputDevice device)
    {
        Debug.Log(string.Format("Connected : name '{0}' and role '{1}'", device.name, device.characteristics.ToString()));



        refreshDevices();

        if(targetDevice.name != device.name)
        {
            spawnedHandModel = Instantiate(handModelPrefab, transform);
        }

    }

    private void onDeviceDisconnected(UnityEngine.XR.InputDevice device)
    {
        Debug.Log(string.Format("Disconnected : name '{0}' and role '{1}'", device.name, device.characteristics.ToString()));
        
        if(targetDevice.name == device.name)
        {
            Destroy(spawnedHandModel);
        }
        refreshDevices();
    }

    private void refreshDevices()
    {
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, listDevices);    
        if(listDevices.Count > 0)
        {
            targetDevice = listDevices[0];
            spawnedHandModel = Instantiate(handModelPrefab, transform);
        }
        else{
            Debug.LogError("No devices found");
        }
    }


    private void logAllDevices()
    {
        foreach (var device in listDevices)
        {
            Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, device.characteristics.ToString()));
        }        
    }




}
