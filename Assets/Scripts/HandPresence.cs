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
    private GameObject spawnedHandModel = null;


    void Awake()
    {

        listDevices = new List<UnityEngine.XR.InputDevice>();

       /* InputDevices.deviceConnected += onDeviceConnected;
        InputDevices.deviceDisconnected += onDeviceDisconnected;*/
    }


    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, listDevices);    
        if(listDevices.Count > 0)
        {
            targetDevice = listDevices[0];
            Debug.LogWarning("TREOUVEVEVEVEVE");
        }
        else
        {
            Debug.LogWarning("NON");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(listDevices.Count == 0)
        {
            UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, listDevices);
            if(listDevices.Count > 0)
            {
            targetDevice = listDevices[0];

                if(spawnedHandModel != null)
                {
                    spawnedHandModel.SetActive(true);
                }
                else
                {
                    spawnedHandModel = Instantiate(handModelPrefab, transform);
                }
                Debug.LogWarning("TREOUVEVEVEVEVE");
            }
            
        }

    }


    private void onDeviceConnected(UnityEngine.XR.InputDevice device)
    {
        Debug.Log(string.Format("Connected : name '{0}' and role '{1}'", device.name, device.characteristics.ToString()));

        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, listDevices);    
        if(listDevices.Count > 0)
        {
            targetDevice = listDevices[0];

            if(spawnedHandModel != null)
            {
                spawnedHandModel.SetActive(true);
            }
            else
            {
                spawnedHandModel = Instantiate(handModelPrefab, transform);
            }
        }

    }

    private void onDeviceDisconnected(UnityEngine.XR.InputDevice device)
    {
        Debug.Log(string.Format("Disconnected : name '{0}' and role '{1}'", device.name, device.characteristics.ToString()));

        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, listDevices);    
        if(listDevices.Count == 0)
        {        
            if(spawnedHandModel != null)
            {
                spawnedHandModel.SetActive(false);
            }
        }
    }

    private void refreshDevices()
    {
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, listDevices);    
        if(listDevices.Count > 0)
        {
            targetDevice = listDevices[0];
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
