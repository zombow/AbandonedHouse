using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Oculus;

public class ControllerManager3 : MonoBehaviour
{
    public GameObject cameraRigForPC;
    public GameObject cameraRigForVIVE;
    public GameObject cameraRigForOCULUS;

    public static ControllerManager3 instance;

    private void Awake()
    {
        instance = this;

#if PC
        cameraRigForPC.SetActive(true);
        cameraRigForVIVE.SetActive(false);
        cameraRigForOCULUS.SetActive(false);
#elif VIVE
        cameraRigForPC.SetActive(false);
        cameraRigForVIVE.SetActive(true);
        cameraRigForOCULUS.SetActive(false);
#else
        cameraRigForPC.SetActive(false);
        cameraRigForVIVE.SetActive(false);
        cameraRigForOCULUS.SetActive(true);
#endif

    }

    [Header("VIVE")]
    public SteamVR_Action_Boolean teleport3;

    public bool TeleportKey3()
    {
#if PC
        return Input.GetKey(KeyCode.T);
#elif VIVE
        return teleport3.GetState(SteamVR_Input_Sources.LeftHand);
#else // OCULUS
        return OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
#endif
    }

    public bool TeleportKeyUp3()
    {
#if PC
        return Input.GetKeyUp(KeyCode.T);
#elif VIVE
        return teleport3.GetStateUp(SteamVR_Input_Sources.LeftHand);
#else // OCULUS
        return OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.LTouch);
#endif
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
