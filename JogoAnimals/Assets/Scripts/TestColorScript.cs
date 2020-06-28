using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColorScript : MonoBehaviour
{
    [SerializeField]
    private Material red;

    public void Red()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void Blue()
    {
        GetComponent<Renderer>().material.color = Color.blue;

    }

    public void Green()
    {
        GetComponent<Renderer>().material.color = Color.green;

    }
}
