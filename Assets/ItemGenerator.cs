using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
	//CarPrefabを入れる
	public GameObject carPrefab;
	//CoinPrefabを入れる
	public GameObject coinPrefab;
	//ConePrefabを入れる
	public GameObject conePrefab;
	//UnityChanを入れる
	public GameObject unitychan;
	//スタート地点のz座標
	private int startPos = -160;
	//ゴール地点のz座標
	private int goalPos = 120;
	//アイテムを出すx方向の範囲
	private float posRange = 3.4f;

	//Unityちゃんのスタート時のz座標
	public float unitychanStartPos;

	// Use this for initialization
	void Start () {
		//シーン中のUnitychanオブジェクトを取得
		this.unitychan = GameObject.Find("unitychan");

		//Unityちゃんの初期z座標を格納
		this.unitychanStartPos = unitychan.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {

		//Unityちゃんが15m進むごとに50ｍ先にオブジェクトを生成
		if((unitychan.transform.position.z - unitychanStartPos ) >= 15 && unitychan.transform.position.z < goalPos - 50) {
			//どのアイテムを出すかをランダムに設定
			int num = Random.Range(1,11);
			if(num <= 2){
				//コーンをx軸方向に一直線に生成
				for(float j = -1;j <= 1; j += 0.4f){
					GameObject cone = Instantiate(conePrefab) as GameObject;
					cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychan.transform.position.z + 50);
				}
			}else{
				//レーンごとにアイテムを生成
				for(int j = -1; j <= 1; j++){
					//アイテムの種類をランダムで決める
					int item = Random.Range(1,11);
					//アイテムを置くz座標のオフセットをランダムに設定
					int offsetZ = Random.Range(-5,6);
					//60% coin,30% car,10% nothing
					if(1 <= item && item <= 6){
						//coin生成
						GameObject coin = Instantiate(coinPrefab) as GameObject;
						coin.transform.position = new Vector3(posRange *j, coin.transform.position.y,unitychan.transform.position.z + 50);
					}else if(7 <= item && item <= 9){
						//car生成
						GameObject car = Instantiate(carPrefab) as GameObject;
						car.transform.position = new Vector3(posRange * j,car.transform.position.y,unitychan.transform.position.z + 50 + offsetZ);
					}
					
				}
			}
			//UnitychanStartPosを更新
			unitychanStartPos = unitychan.transform.position.z;
		}
	}
}
