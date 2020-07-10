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
    public Camera camera;

    bool inSpot = false;
    public string S;
    public GameObject button;
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
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            if (imgGaze.fillAmount == 1)
            {

                if (!inSpot)
                {
                    S = "Completou";
                    print(S);
                    //camera.transform.position = GameObject.Find("MainView").transform.position;
                    inSpot = true;
                    //camera.GetComponent<ResetAll>().Reset();
                    Physics.Raycast(ray, out _hit, distanceOfRay);
                    if (_hit.transform.gameObject.CompareTag("Button"))
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }

                }
            }
        }

    }

    public void GVROn()
    {
        imgGaze.fillAmount = 0;
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
