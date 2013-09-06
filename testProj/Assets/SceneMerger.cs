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
			GameObject root = GameObject.Find( sceneName );
			if( !root ) {
				GameObject currentScene = GameObject.Find ( "CurrentScene" );
				GameObject sceneMerger = GameObject.Find ( "SceneMerger" );
				
				root = new GameObject( sceneName );
				
				GameObject parentScene = null;
				
				if( sceneName == scenes[initialScene] ) {
					parentScene = currentScene;
					root.SetActive( true );
				}else{
					parentScene = sceneMerger;
					root.SetActive( false );
				}
				
				root.transform.parent = parentScene.transform;
				
				Application.LoadLevelAdditive( sceneName );
				
				yield return 0;
				
				foreach( GameObject go in FindObjectsOfType( typeof(GameObject) ) ) {
					if( go != currentScene && go != sceneMerger && go != root && go.transform.parent == null ) {
						go.transform.parent = root.transform;
						go.SetActive ( root.activeSelf );
					}
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
}
