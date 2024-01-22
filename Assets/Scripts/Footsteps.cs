using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private CharacterController character;

    float timer = 0.0f;

    [SerializeField]
    float footstepSpeed = 0.3f;

    public AK.Wwise.Event footsteps;


    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }


    void Update()
    {

        if (character.velocity.magnitude > 1f && Mathf.Abs(character.velocity.y) < 0.1f)
        {
            if(timer > footstepSpeed)
            {
                footsteps.Post(gameObject);
                timer = 0.0f;
            }

            timer += Time.deltaTime;
        }
    }

  
}
