using UnityEngine;
using System.Collections;

public class SceneMerger : MonoBehaviour {
	
	public string [] scenes;
	public int initialScene;
	
	void Awake () {
		StartCoroutine(LoadScenes());
	}
	
	IEnumerator LoadScenes() {
		
		foreach (string sceneName in scenes) {
			Application.LoadLevelAdditive( sceneName );
		}

		yield return 0;
		
		GameObject currentScene = GameObject.Find ( "CurrentScene" );
		GameObject sceneMerger = GameObject.Find ( "SceneMerger" );
		
		foreach( GameObject go in FindObjectsOfType( typeof(GameObject) ) ) {
			if( go != currentScene && go != sceneMerger && go.transform.parent == null ) {
				if( go.name == scenes[initialScene] || go.name == "common" ) {
					go.transform.parent = currentScene.transform;
					go.SetActive ( true );
				}else{
					go.transform.parent = sceneMerger.transform;
					go.SetActive ( false );
				}
			}
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetSceneActive( string sceneName, bool flg )
	{
		foreach ( GameObject go in FindObjectsOfTypeAll( typeof(GameObject) ) ) {
			if( go.name == sceneName ) {
				go.SetActive( flg );
				
				if( flg ) {
					GameObject currentScene = GameObject.Find ( "CurrentScene" );
					go.transform.parent = currentScene.transform;
				}else{
					GameObject sceneMerger = GameObject.Find ( "SceneMerger" );
					go.transform.parent = sceneMerger.transform;
				}
			}
		}
	}

}
