using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    private CharacterController controller;

    float timer = 0.0f;

    [SerializeField]
    float footstepSpeed = 0.3f;

 

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (controller.velocity.magnitude > 1f && Mathf.Abs(controller.velocity.y) < 0.1f) //if the player is moving and grounded
        {
            if (timer > footstepSpeed)
            {
                Debug.Log("footstep");
                FMODUnity.RuntimeManager.PlayOneShot("event:/Footstep");
                timer = 0.0f;
            }

            timer += Time.deltaTime;
        }
    }

}
