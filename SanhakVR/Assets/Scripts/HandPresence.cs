using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public UnityEvent<char> ButtonPress;
    private InputDevice targetDevice;
    public List<GameObject> ControllerPrefabs;

    public char button;

    private GameObject spawnedController;

    // kind of controller
    public InputDeviceCharacteristics ControllerCharacteristic;
    public bool showController = false;
    public GameObject handmodelPrefabs;
    private GameObject spawnedHandModel;
    private Animator handAnimator;

    private void Awake() 
    {
        var gui = GameObject.FindWithTag("GUI").GetComponent<GUIManager>();
        gui.HandInit(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        ControllerInitalize();
    }

    // Update is called once per frame
    void Update()
    {
        if(!targetDevice.isValid)
        {
            ControllerInitalize();
        }
        else
        {
            // If controller not show
            spawnedHandModel.SetActive(!showController);
            spawnedController.SetActive(showController);

            // Start Hand Animation
            if(!showController)
            {
                UpdateHandAnimation();
            }
        }
    }

    private void ControllerInitalize()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(ControllerCharacteristic, devices);

        if(devices.Count >0)
        {   
            targetDevice = devices[0];
            // check controller
            GameObject prefab = ControllerPrefabs.Find(controller => controller.name == targetDevice.name);

            if(prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                spawnedController = Instantiate(ControllerPrefabs[0], transform);
            }
            spawnedHandModel = Instantiate(handmodelPrefabs, transform);
            // get hand motion
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
    }

    //private void ButtonEvent()
    //{
    //    bool eventflag = false;
    //    if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
    //    {
    //        eventflag = true;
    //        if (ControllerCharacteristic == (InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller))
    //        {
    //            button = 'X';
    //        }
    //        if (ControllerCharacteristic == (InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller))
    //        {
    //            button = 'A';
    //        }
    //    }
    //    if (targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue) && secondaryButtonValue)
    //    {
    //        eventflag = true;
    //        if (ControllerCharacteristic == (InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller))
    //        {
    //            button = 'Y';
    //        }
    //        if (ControllerCharacteristic == (InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller))
    //        {
    //            button = 'B';
    //        }
    //    }
    //    if (eventflag)
    //    {
    //        ButtonPress.Invoke(button);
    //    }
    //}

    private void UpdateHandAnimation()
    {
        //ButtonEvent();

        var eventflag = false;
        var button = ' ';

        if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        {
            eventflag = true;
            if (ControllerCharacteristic == (InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller))
            {
                button = 'X';
            }
            if (ControllerCharacteristic == (InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller))
            {
                button = 'A';
            }
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue) && secondaryButtonValue)
        {
            eventflag = true;
            if (ControllerCharacteristic == (InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller))
            {
                button = 'Y';
            }
            if (ControllerCharacteristic == (InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller))
            {
                button = 'B';
            }
        }
        if (eventflag)
        {
            ButtonPress.Invoke(button);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
        {
            // Set Animator Parameter Trggier value
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if(targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.1f)
        {
            // Set Animator Parameter Trggier value
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }

    }
}
