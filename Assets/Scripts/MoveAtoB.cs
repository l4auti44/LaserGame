using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAtoB : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed;

    [SerializeField] private bool rotate = false;
    [SerializeField] private float rotationSpeed = 1f;
    private Transform targetPosition;
    // Update is called once per frame
    private void Start()
    {
        targetPosition = pointA;
    }
    void FixedUpdate()
    {
       transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);

        if (rotate)
        {
            float blend = Mathf.Pow(0.5f, Time.deltaTime * rotationSpeed);
            transform.Rotate(Quaternion.Lerp(targetPosition.rotation, transform.rotation, blend).eulerAngles);
        }


        if (Vector3.Distance(transform.position, targetPosition.position) < 0.001f)
        {
            targetPosition.position = targetPosition.position == pointA.position ? pointB.position : pointA.position;
        }

        
    }
}
