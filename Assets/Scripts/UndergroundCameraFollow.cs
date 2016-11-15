using UnityEngine;
using System.Collections;

public class UndergroundCameraFollow : MonoBehaviour
{
	public Transform Target;
    public float SmoothingFactor = 5f;
	
    Vector3 mOffset;

    void Start ()
    {
        mOffset = transform.position - Target.position;
    }


    void FixedUpdate ()
    {
        Vector3 targetCamPos = Target.position + mOffset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, SmoothingFactor * Time.deltaTime);
		transform.rotation = Quaternion.LookRotation(Target.position - transform.position);
	}
}
