using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class TargetManager : MonoBehaviour {

    const string imageTargetPath = "/StreamingAssets/Contour/liner_image.png";
    public GameObject imagePlate;

    public Texture2D TargetImageTexture;
    public Material TargetImageMaterial;

	// Use this for initialization
	void Start () {

        TargetImageTexture = Resources.Load<Texture2D>(Application.dataPath + "Resources/Contour/liner_image.png");

        Debug.Log("LinerImage is");
        Debug.Log(TargetImageTexture);

        // imagePlate.GetComponent<Renderer>().material.mainTexture = TargetImageTexture;
    }

	
	// Update is called once per frame
	void Update () {
        
	}
}
