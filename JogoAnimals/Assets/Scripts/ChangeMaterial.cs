using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
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
                animal.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                S = "entrei";
                print(S);
            }
        }
    }
}
