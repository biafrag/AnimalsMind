using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{
	public GameObject playerCamera;
	public Transform animalSpot;

	public bool zoom = false;
    public bool zoomJustFinished = false;
    public string S;
    public GameObject button;
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
            zoomJustFinished = true;
            S = "Terminei zoom";
            print(S);
            button.SetActive(true);
            transform.gameObject.GetComponent<TouchAnimal>().inState = true;
            print("zoom off");
        }
    }

    public void Activate()
    {
        // count++;
        // zoom = true;
    }
}
