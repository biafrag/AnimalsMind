using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCloser : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject owlCamera;
    public GvrReticlePointer pointer;
    public int count = 0;
    public Transform Owlview;

    private bool doIt = false;
    public AudioSource audioMain;
    public AudioSource audioOwl;

    Transform currentView;




    public void zoomIn()
    {

        transform.position = Vector3.Lerp(transform.position, Owlview.position, Time.deltaTime * 2);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(doIt)
        {
            zoomIn();
        }
    }
void setupCameras(GameObject c1, GameObject c2, AudioSource audio1, AudioSource audio2)
{
        audio1.Pause();
        audio2.time = audioMain.time;
        c1.SetActive(false);
        c2.SetActive(true);
        audio2.Play();
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
                //if()
                {
                    setupCameras(mainCamera, owlCamera, audioMain, audioOwl);

                }
                doIt = false;
            }
        }
    }
    public void Activate()
    {
        count++;
    }
}
