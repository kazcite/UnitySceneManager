using UnityEngine;
using System.Collections;

// TODO:シーン自体が非アクティブ化されるときはシーンの子要素のアクティブ状態を記憶し、シーンがアクティブ化されるときには記憶した子要素の状態を復帰させる

public class SceneManager : MonoBehaviour {
	
	Hashtable ht = new Hashtable();
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
