﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            var selectionRendering = selection.GetComponent<Renderer>();
            if(selectionRendering != null)
            {
                selectionRendering.material.color = Color.yellow;
            }
        }
    }
}
