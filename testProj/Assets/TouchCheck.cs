﻿using UnityEngine;
using System.Collections;

public class TouchCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
		if( Input.GetMouseButtonDown(0) ) {
			GameObject go = GameObject.Find( "common" );
			go.GetComponent<commonScene>().FadeChangeScene( "scene1", "scene2", 1 );
		}
#elif (UNITY_IPHONE || UNITY_ANDROID)
		switch(Input.GetTouch(0).phase)
		{
			case TouchPhase.Began:
				GameObject go = GameObject.Find( "SceneMerger" );
				go.GetComponent<SceneMerger>().SetSceneActive( "scene1", false );
				go.GetComponent<SceneMerger>().SetSceneActive( "scene2", true );
				break;
			case TouchPhase.Moved:
				break;	
			case TouchPhase.Ended:
				break;
		}
#endif
	}
}
