using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamara : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.Find("PlayerCameraRoot").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
