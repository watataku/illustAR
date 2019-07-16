using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARManager : MonoBehaviour {

    public GameObject imageTarget;
    private Material imageMaterial;
    TargetManager target = new TargetManager();

	// Use this for initialization
	void Start () {
        // imageTargetのマテリアルを取得する
        imageMaterial = imageTarget.GetComponent<Renderer>().material;
        // マテリアルにテクスチャを適用する
        //imageMaterial = target.GetTargetImage(false, imageMaterial);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
