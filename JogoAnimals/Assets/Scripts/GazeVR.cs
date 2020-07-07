using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeVR : MonoBehaviour
{
	public Image imgGaze;

	public float totalTime = 2;
	bool gvrStatus;
	float gvrTimer;

	bool inSpot = false;

	public int distanceOfRay = 10;
	private RaycastHit _hit;

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
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if(Physics.Raycast(ray, out _hit, distanceOfRay))
        {

        	if(imgGaze.fillAmount == 1 && (_hit.transform.CompareTag("Owl") || _hit.transform.CompareTag("Dog")))
        	{
        		print("hit owl!");
        		if (!inSpot)
        		{
        			print("zoom on");
        			imgGaze.fillAmount = 0;
        			inSpot = true; //triggar 1 vez só (se nao crasha)
        			_hit.transform.gameObject.GetComponent<ZoomIn>().zoomIn();

        		}
        	}
        }
    }

    public void GVROn()
    {
    	gvrStatus = true;
    }

	public void GVROff()
    {
    	gvrStatus = false;
    	gvrTimer = 0;
    	imgGaze.fillAmount = 0;
    }
}
