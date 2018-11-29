using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class ARManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator SetVRDevice(string Device, bool isEnabled){
        XRSettings.LoadDeviceByName(Device);
        yield return null;
        XRSettings.enabled = isEnabled;
        Debug.Log("cardboard is called");
    }
}
