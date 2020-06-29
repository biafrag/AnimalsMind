using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCloser : MonoBehaviour
{
    public Camera cam;
    public GameObject cam1;
    public GameObject cam2;
    public GvrReticlePointer pointer;
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
                audioMain.Pause();
                audioOwl.time = audioMain.time;
                Destroy(GameObject.Find("GvrReticlePointer1"));
                cam1.tag = "OwlCamera";
                cam1.SetActive(false);
                cam2.tag = "MainCamera";
                cam2.SetActive(true);
                audioOwl.Play();
                doIt = false;
                print(Status);
            }
        }
    }
    public void Activate()
    {
        count++;
    }
}
