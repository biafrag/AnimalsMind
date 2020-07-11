using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChangeForAnimalVision : MonoBehaviour
{
    public GameObject[] Owl;
    public GameObject[] Dog;
    public GameObject[] Cat;
    public GameObject[] Snake;
    public string currentAnimal = "Bolotas";
    public string CurrentAnimal;
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
        if (string.Compare(animal, "Owl") == 0 || string.Compare(animal, "default") == 0)
        {
            Owl[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("PostProcessing");
            transform.position = Owl[(int)Part.Animal].transform.position;
            AudioSource mainAudio = GameObject.FindObjectOfType<AudioSource>();
            AudioSource audio = Owl[(int)Part.Audio].GetComponent<AudioSource>();
            mainAudio.outputAudioMixerGroup = audio.outputAudioMixerGroup;
        }
        else if (string.Compare(animal, "AnimatedDog") == 0)
        {

            Dog[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("PostProcessing");
            transform.position = Dog[(int)Part.Animal].transform.position;
            //AudioSource mainAudio = GameObject.FindObjectOfType<AudioSource>();
            //mainAudio.outputAudioMixerGroup = B.outputAudioMixerGroup;
            currentAnimal = animal;
        }
        else if (string.Compare(animal, "Cat") == 0)
        {

            Cat[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("PostProcessing");
            transform.position = Cat[(int)Part.Animal].transform.position;
            //AudioSource mainAudio = GameObject.FindObjectOfType<AudioSource>();
            //mainAudio.outputAudioMixerGroup = B.outputAudioMixerGroup;
            currentAnimal = animal;
        }
        else if (string.Compare(animal, "Snake") == 0)
        {

            Snake[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("PostProcessing");
            transform.position = Snake[(int)Part.Animal].transform.position;
            snakeMode(true);
            //AudioSource mainAudio = GameObject.FindObjectOfType<AudioSource>();
            //mainAudio.outputAudioMixerGroup = B.outputAudioMixerGroup;
            currentAnimal = animal;
        }
        currentAnimal = animal;
        GetComponent<GazeInside>().imgGaze.fillAmount = 0;

        GetComponent<GazeInside>().inState = true;
        print(CurrentAnimal);
    }
    public void changeOther(string animalGo)
    {
        if(string.Compare(currentAnimal, "Owl") == 0 || string.Compare(currentAnimal, "default") == 0)
        {
            Owl[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("Default");
        }
        else if (string.Compare(currentAnimal, "AnimatedDog") == 0)
        {

            Dog[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("Default");
        }
        else if(string.Compare(currentAnimal, "Cat") == 0)
        {
            Cat[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("Default");
        }
        else if (string.Compare(currentAnimal, "Snake") == 0)
        {
            snakeMode(false);
            Snake[(int)Part.PostProcessing].layer = LayerMask.NameToLayer("Default");
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
                a.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                S = "entrei";
                print(S);
            }
        }
        else
        {
            foreach (GameObject a in animals)
            {
                a.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
                S = "entrei";
                print(S);
            }

            S = "entrei";
            print(S);
        }
    }
}