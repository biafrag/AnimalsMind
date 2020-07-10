using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchAnimal : MonoBehaviour
{
   public Image imgGaze;

    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;

    public bool inState;

    public int distanceOfRay = 10;
    private RaycastHit _hit;
    public GameObject button;
    public string S;
    GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        inState = false;
        cam = GameObject.Find("MainCameraRig");
    }

    // Update is called once per frame
    void Update()
    {
       if (inState)
        {
            if (gvrStatus)
            {
                gvrTimer += Time.deltaTime;
                imgGaze.fillAmount = gvrTimer / totalTime;
            }

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(ray, out _hit, distanceOfRay))
            {
                if (imgGaze.fillAmount == 1)
                {
                    S = "Deu ruim";
                    print(S);
                    GVROff();
                    if(!_hit.transform.gameObject.CompareTag("Button"))
                    {
                        cam.transform.gameObject.GetComponent<ChangeForAnimalVision>().change(_hit.transform.name);
                        inState = false;
                    }
                }
            }
        }
    }

    public void GVROn()
    {
        imgGaze.fillAmount = 0;
        gvrTimer = 0;
        gvrStatus = true;
        S = "Touch Animal";
        print(S);
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }
    
}
