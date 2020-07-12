using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Audio;


public class ChangeForAnimalVision : MonoBehaviour
{
    public GameObject[] Owl;
    public GameObject[] Dog;
    public GameObject[] Snake;
    public GameObject[] Tiger;
    public GameObject[] Squirrel;
    public string currentAnimal = "Bolotas";
    public AudioMixerGroup mainMixer;
    public string CurrentAnimal;
    public GameObject Pointer;
    public GameObject fire;
    public GameObject cloud1;
    public GameObject cloud2;

    enum Part
    {
        Animal,
        PostProcessing,
        Audio
    }
    public string S;
    public void change(string animal)
    {
        AudioSource mainAudio = GameObject.FindObjectOfType<AudioSource>();
        S = "Entrou";
        print(S);
        if (string.Compare(animal, "Owl") == 0 || string.Compare(animal, "default") == 0)
        {
            Owl[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("PostProcessing");
            transform.position = Owl[(int)Part.Animal].transform.position;
            AudioSource audio = Owl[(int)Part.Audio].GetComponent<AudioSource>();
            mainAudio.outputAudioMixerGroup = audio.outputAudioMixerGroup;
            mainAudio.volume = 0.12f;
        }
        else if (string.Compare(animal, "AnimatedDog") == 0)
        {

            Dog[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("PostProcessing");
            transform.position = Dog[(int)Part.Animal].transform.position;
            Pointer.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            //AudioSource mainAudio = GameObject.FindObjectOfType<AudioSource>();
            //mainAudio.outputAudioMixerGroup = B.outputAudioMixerGroup;
            mainAudio.volume = 1.0f;
            currentAnimal = animal;
        }
        else if (string.Compare(animal, "Tiger") == 0)
        {

            Tiger[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("PostProcessing");
            transform.position = Tiger[(int)Part.Animal].transform.position;
            //AudioSource mainAudio = GameObject.FindObjectOfType<AudioSource>();
            //mainAudio.outputAudioMixerGroup = B.outputAudioMixerGroup;
            mainAudio.volume = 1.0f;
            currentAnimal = animal;
        }
        else if (string.Compare(animal, "Snake") == 0)
        {

            Snake[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("PostProcessing");
            transform.position = Snake[(int)Part.Animal].transform.position;
            snakeMode(true);
            mainAudio.Pause();
            currentAnimal = animal;
           // Handheld.Vibrate();
        }
        else if (string.Compare(animal, "Squirrel") == 0)
        {

            Squirrel[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("PostProcessing");
            transform.position = Squirrel[(int)Part.Animal].transform.position;
            squirrelMode(true);
            currentAnimal = animal;
        }

        currentAnimal = animal;
        GetComponent<GazeInside>().imgGaze.fillAmount = 0;

        GetComponent<GazeInside>().inState = true;
        print(CurrentAnimal);
    }
    public void changeOther(string animalGo)
    {
        AudioSource mainAudio = GameObject.FindObjectOfType<AudioSource>();

        if (string.Compare(currentAnimal, "Owl") == 0 || string.Compare(currentAnimal, "default") == 0)
        {
            Owl[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("Default");
            mainAudio.outputAudioMixerGroup = mainMixer;
            mainAudio.volume = 0.3f;
        }
        else if (string.Compare(currentAnimal, "AnimatedDog") == 0)
        {

            Dog[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("Default");
            Pointer.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
            mainAudio.outputAudioMixerGroup = mainMixer;
            mainAudio.volume = 0.3f;
        }
        else if(string.Compare(currentAnimal, "Tiger") == 0)
        {
            Tiger[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("Default");
            mainAudio.outputAudioMixerGroup = mainMixer;
            mainAudio.volume = 0.3f;
        }
        else if (string.Compare(currentAnimal, "Snake") == 0)
        {
            snakeMode(false);
            Snake[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("Default");
            mainAudio.outputAudioMixerGroup = mainMixer;
            mainAudio.volume = 0.3f;
            mainAudio.UnPause();
        }
        else if (string.Compare(currentAnimal, "Squirrel") == 0)
        {
            squirrelMode(false);
            Squirrel[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("Default");
            mainAudio.outputAudioMixerGroup = mainMixer;
            mainAudio.volume = 0.3f;
        }
        change(animalGo);
    }

    void snakeMode(bool isSnake)
    {
        S = "entrei";
        print(S);
        GameObject[] animals;
        animals = GameObject.FindGameObjectsWithTag("Animals");

        if(isSnake)
        {
            foreach (GameObject a in animals)
            {
                Renderer r = a.GetComponent<Renderer>();
                if(r)
                {
                    r.material.EnableKeyword("_EMISSION");
                    S = "entrei";
                    print(S);
                }
            }
        }
        else
        {
            foreach (GameObject a in animals)
            {
                Renderer r = a.GetComponent<Renderer>();
                if (r)
                {
                    r.material.DisableKeyword("_EMISSION");
                    S = "entrei";
                    print(S);
                }
            }
        }
    }
    void squirrelMode(bool inSquirrel)
    {
        S = "entrei";
        print(S);
        GameObject[] animals;
        animals = GameObject.FindGameObjectsWithTag("Animals");
        if(inSquirrel)
        {
            foreach (GameObject animal in animals)
            {
                Animator a = animal.GetComponent<Animator>();
                if (a)
                {
                    a.speed = 0.3f;
                }
                fire.GetComponent<ParticleSystem>().playbackSpeed = 0.2f;
                cloud1.GetComponent<ParticleSystem>().playbackSpeed = 0.2f;
                cloud2.GetComponent<ParticleSystem>().playbackSpeed = 0.2f;

                AudioSource mainAudio = GameObject.FindObjectOfType<AudioSource>();

                mainAudio.pitch = 0.5f;
            }
        }
        else
        {
            foreach (GameObject animal in animals)
            {
                Animator a = animal.GetComponent<Animator>();
                if (a)
                {
                    if(string.Compare(a.name, "Hornet") == 0)
                    {
                        a.speed = 5.0f;
                    }
                    else
                    {
                        a.speed = 1.0f;
                    }
                }
                fire.GetComponent<ParticleSystem>().playbackSpeed = 1.0f;
                cloud1.GetComponent<ParticleSystem>().playbackSpeed = 1.0f;
                cloud2.GetComponent<ParticleSystem>().playbackSpeed = 1.0f;

                AudioSource mainAudio = GameObject.FindObjectOfType<AudioSource>();

                mainAudio.pitch = 1.0f;
            }
        }
    }
}