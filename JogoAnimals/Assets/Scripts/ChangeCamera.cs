using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject cam;
    public string S;
    public AudioSource newAudio;

    public void changeCamera()
    {
        GameObject mainCam = GameObject.Find("MainCamera");
        AudioSource audio1 = GameObject.Find("MainAudio").GetComponent<AudioSource>();
        audio1.Pause();
        newAudio.time = audio1.time;
        mainCam.SetActive(false);
        cam.SetActive(true);
        newAudio.Play();


    }
}
