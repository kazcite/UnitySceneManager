using UnityEngine;
using System.Collections;

public class TouchCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
		if( Input.GetMouseButtonDown(0) ) {
			Application.LoadLevelAdditive( "scene2" );
		}
#elif (UNITY_IPHONE || UNITY_ANDROID)
		switch(Input.GetTouch(0).phase)
		{
			case TouchPhase.Began:
				Application.LoadLevel( "scene2" );
				break;
			case TouchPhase.Moved:
				break;	
			case TouchPhase.Ended:
				break;
		}
#endif
	}
}
