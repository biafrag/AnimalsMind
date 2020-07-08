using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAll : MonoBehaviour
{
    public GameObject button;
    public string S;
    public void Reset()
    {
        //Reseta do GazeVR
        //inState
        /*GameObject[] animals = GameObject.FindGameObjectsWithTag("Animals");
        transform.gameObject.GetComponent<GazeVR>().GVROff();
        transform.gameObject.GetComponent<GazeVR>().inState = true;
        foreach (GameObject animal in animals)
        {
            transform.gameObject.GetComponent<TouchAnimal>().GVROff();
            animal.transform.gameObject.GetComponent<TouchAnimal>().inState = false;
        }
        S = animals[0].name;
        print(S);
        button.SetActive(false);*/

    }
}
