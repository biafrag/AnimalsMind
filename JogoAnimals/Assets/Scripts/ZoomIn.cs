using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{
	public GameObject playerCamera;
	public Transform animalSpot;

	bool zoom = false;

	public void zoomIn()
    {
    	zoom = true;
    }

    void LateUpdate()
    {
        if(zoom)
        {
        	print("zooming");
            playerCamera.transform.position = Vector3.MoveTowards(playerCamera.transform.position, animalSpot.position, Time.deltaTime * 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCamera.transform.position == animalSpot.position)
        {
        	zoom = false;
        	print("zoom off");
        }
    }

    public void Activate()
    {
        // count++;
        // zoom = true;
    }
}
