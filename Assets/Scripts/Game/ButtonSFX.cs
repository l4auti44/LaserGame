using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{


    public static void mainSelect()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Select");
    }

    public static void levelSelect()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Level Select");
    }
}
