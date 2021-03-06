﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveLight : MonoBehaviour {
    public VolumetricLight viewpoint;
    public float rotationSpeed;
    public List<GameObject> raycastObject;

    public LayerMask PlatformLayer;

    private CapsuleCollider myCollider;
    
    // Use this for initialization
    void Start () {
        myCollider = gameObject.GetComponent<CapsuleCollider>();
        //myLight = viewpoint.gameObject.GetComponent<Light>();

        viewpoint.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (float)(myCollider.height / 2), gameObject.transform.position.z);
        viewpoint.transform.eulerAngles = new Vector3(0, 90, 0);
   }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            var distance = Time.deltaTime * rotationSpeed;
            viewpoint.transform.Rotate(distance, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var distance = Time.deltaTime * -rotationSpeed;
            viewpoint.transform.Rotate(distance, 0, 0);
        }

        //Raycast the beam of light
        List<RaycastHit> raycastsHit = new List<RaycastHit>();
        RaycastHit[] hits;

        // Loop through all opbejcts at the edge fo the cone and detect hits.
        foreach (GameObject obj in raycastObject)
        {
            int layerMark = LayerMask.GetMask("Platform");
            hits = Physics.RaycastAll(viewpoint.transform.position, obj.transform.position);
            if (hits != null)
            {
                foreach (RaycastHit hit in hits)
                {
                    //print(hit.transform.gameObject);
                    if (hit.transform.gameObject.tag == "PlatformTag" && hit.transform.gameObject.GetComponent<PlatformScript>())
                    {
                        hit.transform.gameObject.GetComponent<PlatformScript>().ChangeMaterial();
                    }
                }
            }

            // Add custom logic for what should happen on a raycast hit here
        }
     
    }
}
