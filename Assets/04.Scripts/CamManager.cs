using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public Camera MainCam;
    public Camera BossCam;

    public void CamSwitch()
    {
        if(MainCam.enabled)
        {
            MainCam.enabled = false;
            BossCam.enabled = true;
        }
        else
        {
            BossCam.enabled = false;
            MainCam.enabled = true;
        }
    }
}
