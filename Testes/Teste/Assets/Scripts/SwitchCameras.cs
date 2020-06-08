using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwitchCameras: MonoBehaviour
{
    public GameObject c1;
    public GameObject c2;
    public string status = "Camera1";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space))
        {
            if (c1.activeSelf)
            {
                c1.SetActive(false);
                c2.SetActive(true);
                print(status);
            }
            else
            {
                c2.SetActive(false);
                status = "Camera1";
                c1.SetActive(true);
                print(status);
            }
        }
    }
}
