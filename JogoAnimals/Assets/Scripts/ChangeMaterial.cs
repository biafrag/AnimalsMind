using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public GameObject fire;
    public GameObject cloud1;
    public GameObject cloud2;
    public string S;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            S = "entrei";
            print(S);
            GameObject[] animals;
            animals = GameObject.FindGameObjectsWithTag("Animals");

            foreach (GameObject animal in animals)
            {
                Animator a = animal.GetComponent<Animator>();
                if(a)
                {
                    a.speed = 0.3f;
                }
                fire.GetComponent<ParticleSystem>().playbackSpeed = 0.3f;
                cloud1.GetComponent<ParticleSystem>().playbackSpeed = 0.3f;
                cloud2.GetComponent<ParticleSystem>().playbackSpeed = 0.3f;

                AudioSource mainAudio = GameObject.FindObjectOfType<AudioSource>();

                mainAudio.pitch = 0.5f;
            }
        }
    }
}
