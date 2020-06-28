using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCloser : MonoBehaviour
{
    public Camera cam;
    public GameObject cam1;
    public GameObject cam2;
    public int count = 0;
    public string Status;
    public Transform currentView;
    private bool doIt = false;
    public AudioSource audioMain;
    public AudioSource audioOwl;


    public void zoomIn()
    {

        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * 2);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(doIt)
        {
            zoomIn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(count == 1)
        {
            if (doIt == false)
            {
                doIt = true;
            }
        }
        else
        {
            if(doIt)
            {
                cam1.SetActive(false);
                float time = audioMain.time;
                audioOwl.SetScheduledStartTime(time);
                cam2.SetActive(true);

                print(Status);
            }
        }
    }
    public void Activate()
    {
        count++;
    }
}
