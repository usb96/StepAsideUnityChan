using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour {
	//Unityちゃんを入れる
	private GameObject unitychan;

	// Use this for initialization
	void Start () {
		
		//シーン中のunitychanオブジェクトを取得
		this.unitychan = GameObject.Find("unitychan");

	}
	
	// Update is called once per frame
	void Update () {
		
		//unityちゃんよりz座標が小さくなったものをDestroyしていく
		if(this.transform.position.z < unitychan.transform.position.z){
			Destroy(this.gameObject);
		}
		
	}
}
