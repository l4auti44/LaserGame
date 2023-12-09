using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Transform laserOrigin;
    [SerializeField] private GameObject laserPivot;
    [SerializeField] private float laserMaxDistance = 30f;


    [SerializeField] private bool DEBUG = false;
    // Start is called before the first frame update
    void Start()
    {
        laserPivot.transform.localScale = new Vector3(1, laserMaxDistance, 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(laserOrigin.position, laserOrigin.up);
        Debug.DrawRay(ray.origin, ray.direction * laserMaxDistance, Color.red);

        if (Physics.Raycast(ray, out hit, laserMaxDistance))
        {
            if (DEBUG) Debug.Log("Object Find by laser");
            laserPivot.transform.localScale = new Vector3(1, hit.distance, 1);
            if (hit.transform.CompareTag("Player"))
            {
                if(DEBUG) Debug.Log("Player Die");
                GameObject playerParent = hit.transform.parent.gameObject;
                //playerParent.GetComponent<FirstPersonController>().RestartPosition();
                

            }

        }
        else
        {
            laserPivot.transform.localScale = new Vector3(1, laserMaxDistance, 1);
        }
    }
}
