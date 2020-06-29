using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InitialPosition : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public Vector3 myCamPos = Vector3.zero;

    void Start()
    {
        myCamPos = cam1.transform.position;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam1.transform.position = myCamPos;

        }
    }
}
