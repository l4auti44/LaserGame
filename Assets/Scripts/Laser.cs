using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Transform laserOrigin;
    [SerializeField] private GameObject laserPivot;
    [SerializeField] private float laserMaxDistance = 30f;
    [SerializeField] private float damage = 15f;
    //[SerializeField] private float knockbackStrenght = 4f;

    //[SerializeField] private bool DEBUG = false;
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
            
            laserPivot.transform.localScale = new Vector3(1, hit.distance, 1);
            if (hit.transform.CompareTag("Player"))
            {
                //GameObject playerParent = hit.transform.gameObject;
                HealthSystem.instance.TakeDamage(damage);
                //playerParent.GetComponent<Rigidbody>().AddForce(laserOrigin.up * knockbackStrenght) ;
                //playerParent.GetComponent<FirstPersonController>().RestartPosition();
                

            }

        }
        else
        {
            laserPivot.transform.localScale = new Vector3(1, laserMaxDistance, 1);
        }
    }
}
