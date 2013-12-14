using UnityEngine;
using System.Collections;

public class commonSceneInit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		GameObject go = GameObject.Find ("fadeScreen" );
		UISprite sprite = (UISprite)go.GetComponent ("UISprite");
		sprite.alpha = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
