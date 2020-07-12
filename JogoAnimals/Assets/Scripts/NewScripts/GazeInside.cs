using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeInside : MonoBehaviour
{
    public Image imgGaze;

    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;

    bool inSpot = false;

    public int distanceOfRay = 10;
    private RaycastHit _hit;

    public string S;
    public bool inState;
    // Start is called before the first frame update
    void Start()
    {
        inState = false;
        gvrStatus = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (inState)
        {
            if (gvrStatus)
            {
                S = imgGaze.fillAmount.ToString();
                print(S);
                gvrTimer += Time.deltaTime;
                imgGaze.fillAmount = gvrTimer / totalTime;
            }

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(ray, out _hit, distanceOfRay))
            {
                if (imgGaze.fillAmount == 1)
                {
                    if (!inSpot)
                    {
                        if (_hit.transform)
                        {
                            imgGaze.fillAmount = 0;
                            inState = false;
                            inSpot = true; //triggar 1 vez só (se nao crasha)
                            //_hit.transform.gameObject.GetComponent<ZoomIn>().zoomIn();
                            transform.gameObject.GetComponent<ChangeForAnimalVision>().changeOther(_hit.transform.name);
                            //inState = false;
                        }
                    }
                }
            }
        }
    }

    public void GVROn()
    {
        imgGaze.fillAmount = 0;
        inSpot = false;
        gvrTimer = 0;
        gvrStatus = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
        inSpot = false;
    }
    
}
