using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackToMainView : MonoBehaviour
{
    public Image imgGaze;

    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay = 10;
    private RaycastHit _hit;
    public GameObject camera;

    bool inSpot = false;
    public string S;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
            S = "Carregando";
            print(S);
        }

        if (imgGaze.fillAmount == 1)
        {

            if (!inSpot)
            {
                //camera.transform.position = GameObject.Find("MainView").transform.position;
                inSpot = true;
                //camera.GetComponent<ResetAll>().Reset();
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                Physics.Raycast(ray, out _hit, distanceOfRay);
                S = "Completou";
                print(S);
                if(!_hit.transform)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }

    }

    public void GVROn()
    {
        inSpot = false;
        S = "Entrou";
        print(S);
        gvrStatus = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
        S = "";
    }
}
