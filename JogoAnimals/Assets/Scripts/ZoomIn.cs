using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            playerCamera.transform.position = Vector3.MoveTowards(playerCamera.transform.position, animalSpot.position, Time.deltaTime * 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCamera.transform.position == animalSpot.position)
        {
            if(zoom == true)
            {
                zoom = false;
                zoomJustFinished = true;
                button.SetActive(true);
                transform.gameObject.GetComponent<TouchAnimal>().inState = true;
            }
        }
    }
}
