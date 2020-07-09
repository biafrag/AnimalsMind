using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChangeForAnimalVision : MonoBehaviour
{
    public GameObject[] Owl;
    public GameObject[] Dog;

    enum Part
    {
        Animal,
        PostProcessing,
        Audio
    }
    public string S;
    public void change(string animal)
    {
        S = "Entrou";
        print(S);
        if (string.Compare(animal,"Owl") == 0)
        {
            Owl[(int) Part.PostProcessing].layer = LayerMask.NameToLayer("PostProcessing");
            transform.position = Owl[(int)Part.Animal].transform.position;
            AudioSource mainAudio = GameObject.FindObjectOfType<AudioSource>();
            AudioSource audio = Owl[(int)Part.Audio].GetComponent<AudioSource>();

            mainAudio.outputAudioMixerGroup = audio.outputAudioMixerGroup;
        }
        else if(string.Compare(animal, "AnimatedDog") == 0)
        {

            Dog[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("PostProcessing");
            transform.position = Dog[(int)Part.Animal].transform.position;
            //AudioSource mainAudio = GameObject.FindObjectOfType<AudioSource>();
            //mainAudio.outputAudioMixerGroup = B.outputAudioMixerGroup;
        }
    }
}
