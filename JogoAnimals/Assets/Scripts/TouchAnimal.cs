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

    public string S;
    // Start is called before the first frame update
    void Start()
    {
        inState = false;
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
                    transform.gameObject.GetComponent<ChangeCamera>().changeCamera();
                    inState = false;
                }
            }
        }
    }

    public void GVROn()
    {
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
