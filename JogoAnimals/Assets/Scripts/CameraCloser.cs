using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCloser : MonoBehaviour
{
    public Camera cam;
    public GameObject cam1;
    public GameObject cam2;
    public int count = 0;
    public void zoomIn()
    {
        if(count <= 0)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, -1500, Time.deltaTime * 2);
            count++;
        }
        else
        {
            cam1.SetActive(false);
            cam2.SetActive(true);

        }
    }
}
