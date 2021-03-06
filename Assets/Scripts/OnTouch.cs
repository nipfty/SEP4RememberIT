﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouch : MonoBehaviour {

    private RuntimePlatform platform = Application.platform;
	public delegate void Clicked (string item);
	public static event Clicked hasClicked;
	private bool listen = true;

	void OnEnable(){
		UIScript.togglePause += toggleListen;
	}
	void onDisable(){
		UIScript.togglePause -= toggleListen;
	}
    void Update()
	{if (listen) {
			if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) {
				if (Input.touchCount > 0) {
					if (Input.GetTouch (0).phase == TouchPhase.Began) {
						checkTouch (Input.GetTouch (0).position);
					}
				}
			} else if (platform == RuntimePlatform.WindowsEditor) {
				if (Input.GetMouseButtonDown (0)) {
					checkTouch (Input.mousePosition);
				}
			}
		}
    }

    void checkTouch(Vector3 pos)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);
        Collider2D hit = Physics2D.OverlapPoint(touchPos);

        if (hit)
        {
			if(hasClicked!=null)hasClicked(hit.transform.gameObject.name);
        }
    }

	void toggleListen(){
		if (listen) {
			listen = false;
		} else
			listen = true;
	}
}
