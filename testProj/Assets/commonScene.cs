using UnityEngine;
using System.Collections;

public class commonScene : MonoBehaviour {

	UISprite fadeSprite;

	string prevScene;
	string nextScene;

	bool isFadeIn;
	bool isFading;

	float fadeTime;

	// Use this for initialization
	void Start () {
	
		this.isFading = false;
		this.isFadeIn = false;
		this.fadeTime = 0;

		GameObject go = GameObject.Find ("fadeScreen" );
		this.fadeSprite = (UISprite)go.GetComponent ("UISprite");
		this.fadeSprite.alpha = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if( this.isFading ) {
			if( this.isFadeIn ) {
				this.fadeSprite.alpha += Time.deltaTime/this.fadeTime;
				if( this.fadeSprite.alpha >= 1.0f ) {
					this.fadeSprite.alpha = 1.0f;
					this.fadeSprite.color = new Color( 0, 0, 0, this.fadeSprite.alpha );
					this.isFadeIn = false;
					
					GameObject go = GameObject.Find( "SceneMerger" );
					go.GetComponent<SceneMerger>().SetSceneActive( nextScene, true );
					go.GetComponent<SceneMerger>().SetSceneActive( prevScene, false );
				}
			}else{
				this.fadeSprite.alpha -= Time.deltaTime/this.fadeTime;
				if( this.fadeSprite.alpha <= 0.0f ) {
					this.fadeSprite.alpha = 0.0f;
					this.fadeSprite.color = new Color( 0, 0, 0, this.fadeSprite.alpha );
					this.isFading = false;
				}
			}
		}
	}

	public void FadeChangeScene( string prevScene, string nextScene, float fadeTime ) {
		if( fadeTime <= 0 ) {
			GameObject go = GameObject.Find( "SceneMerger" );
			go.GetComponent<SceneMerger>().SetSceneActive( nextScene, true );
			go.GetComponent<SceneMerger>().SetSceneActive( prevScene, false );
		}else{
			this.isFading = true;
			this.isFadeIn = true;
			this.fadeTime = fadeTime;
			this.nextScene = nextScene;
			this.prevScene = prevScene;
		}

	}
}
