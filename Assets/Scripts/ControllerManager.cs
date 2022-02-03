using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerManager : MonoBehaviour
{
    public GameObject cameraRigForPC;
    public GameObject cameraRigForVIVE;
    public GameObject cameraRigForOCULUS;

    public static ControllerManager instance;
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
#else // OCULUS
        cameraRigForPC.SetActive(false);
        cameraRigForVIVE.SetActive(false);
        cameraRigForOCULUS.SetActive(true);
#endif

    }

    [Header("VIVE")]
    public SteamVR_Action_Boolean teleport;

    public bool TeleportKey()
    {
#if PC
        return Input.GetKey(KeyCode.T);
#elif VIVE
        return teleport.GetState(SteamVR_Input_Sources.LeftHand);
#else // OCULUS
        return false;
#endif
    }

    public bool TeleportKeyUp()
    {
#if PC
        return Input.GetKeyUp(KeyCode.T);
#elif VIVE
        return teleport.GetStateUp(SteamVR_Input_Sources.LeftHand);
#else // OCULUS
        return false;
#endif
    }

    public bool Fire()
    {
#if PC
        return Input.GetButtonDown("Fire1");
#elif VIVE
        return teleport.GetStateDown(SteamVR_Input_Sources.RightHand);
#else // OCULUS
        return false;
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
