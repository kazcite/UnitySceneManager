using UnityEngine;
using System.Collections;

public class SceneMerger : MonoBehaviour {
	
	public string [] scenes;
	public int initialScene;
	
	void Awake () {
		StartCoroutine(LoadScenes());
	}
	
	IEnumerator LoadScenes() {
		
		// 最初にすべてのシーンを加算読み込み
		foreach (string sceneName in scenes) {
			Application.LoadLevelAdditive( sceneName );
		}

		// 実際に読み込まれるのは1フレーム後なので1フレ待つ
		yield return 0;
		
		GameObject currentScene = GameObject.Find ( "CurrentScene" );
		GameObject sceneMerger = GameObject.Find ( "SceneMerger" );
		
		// 全GameObjectを探索してシーンのトップを探す（シーンファイル名と同じGameObject）
		foreach( GameObject go in FindObjectsOfType( typeof(GameObject) ) ) {
			if( go != currentScene && go != sceneMerger && go.transform.parent == null ) {
				// commonシーンと初期シーンを読み込み
				// TODO:初期シーンのリスト化、コンストラクタ的なコンポーネントの呼び出し
				if( go.name == "Camera" ) { continue; }
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
					// TODO:コンストラクタ的なコンポーネントの呼び出し
					GameObject currentScene = GameObject.Find ( "CurrentScene" );
					go.transform.parent = currentScene.transform;
				}else{
					// TODO:デストラクタ的なコンポーネントの呼び出し
					GameObject sceneMerger = GameObject.Find ( "SceneMerger" );
					go.transform.parent = sceneMerger.transform;
				}
			}
		}
	}

}
