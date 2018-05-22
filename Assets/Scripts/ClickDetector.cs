﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickDetector : MonoBehaviour, IPointerClickHandler {
    

    // Use this for initialization
    void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void OnPointerClick(PointerEventData eventData)
    {
       
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }
}