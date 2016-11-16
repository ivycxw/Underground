using UnityEngine;
using System.Collections;

public class CoinRotator : MonoBehaviour {

	private MeshRenderer mr;

	// Use this for initialization
	void Start () {
		mr = GetComponent<MeshRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		mr.transform.Rotate(Vector3.up * Time.deltaTime * 50);
//		transform.Rotate(Vector3.up * Time.deltaTime * 50);
	}
}
