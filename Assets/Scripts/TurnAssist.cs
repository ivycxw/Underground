/*
    Team Underground

    Xiaowei Chen
    Hyun Seo Chung
    Hui Feng
    Sangmin Lee
    Zachary Peterson
*/

using UnityEngine;
using System.Collections;

public class TurnAssist : MonoBehaviour {
	
	private bool shouldFace = false;
	private Vector3 facePosition = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldFace) {
			transform.LookAt (facePosition);
			shouldFace = false;
		}
	}

	public void FacePosition (Vector3 position) {
		facePosition = position;
		shouldFace = true;
	}

	public void FaceTransform (Transform transform) {
		FacePosition (transform.position);
	}

	public void FaceObject (GameObject gameObject) {
		FacePosition (gameObject.transform.position);
	}
}
