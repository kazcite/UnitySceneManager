using UnityEngine;
using System.Collections;

public class SceneMove : MonoBehaviour {
	
	void LoadScene1 () {
		GameObject go = GameObject.Find( "SceneMerger" );
		go.GetComponent<SceneMerger>().SetSceneActive( "scene1", true );
		go.GetComponent<SceneMerger>().SetSceneActive( "scene2", false );
	}
	
	void LoadScene2 () {
		GameObject go = GameObject.Find( "SceneMerger" );
		go.GetComponent<SceneMerger>().SetSceneActive( "scene1", false );
		go.GetComponent<SceneMerger>().SetSceneActive( "scene2", true );
	}
	
}
