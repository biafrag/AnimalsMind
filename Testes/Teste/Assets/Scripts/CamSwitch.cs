using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
	public GameObject mainCamera;
	public GameObject owlCamera;
	
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
        	if(mainCamera.activeSelf)
        	{
        		mainCamera.SetActive(false);
        		owlCamera.SetActive(true);
        	}
        	else
        	{
        		mainCamera.SetActive(true);
        		owlCamera.SetActive(false);
        	}
        }
    }

}
