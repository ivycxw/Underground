using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
	public GameObject MainMenu;
	public GameObject CreditsMenu;
	public GameObject RoomMenu;

	public GameObject Camera;
	public Transform CameraTarget;
	public float RotationRate;

	public RectTransform ScrollingCreditText;
	public float CreditScrollRate;

	private Vector3 mCameraOffset;
	private float mCurrentRotation;

	private bool mCurrentlyScrolling;
	private float mStartingCreditsHeight;

	// Use this for initialization
	void Start ()
	{
		mStartingCreditsHeight = ScrollingCreditText.anchoredPosition.y;
		mCameraOffset = Camera.transform.position - CameraTarget.position;
		Camera.transform.rotation = Quaternion.LookRotation(-mCameraOffset);
		mCurrentRotation = 0.0f;
	}

	// Update is called once per frame
	void Update ()
	{
		if (mCurrentlyScrolling)
		{
			ScrollingCreditText.anchoredPosition += new Vector2(0.0f, CreditScrollRate) * Time.deltaTime;
			if (ScrollingCreditText.anchoredPosition.y >= -mStartingCreditsHeight)
			{
				mCurrentlyScrolling = false;
			}
		}

		mCurrentRotation = (mCurrentRotation + RotationRate * Time.deltaTime) % 360;
		Vector3 newOffset = Quaternion.AngleAxis(mCurrentRotation, Vector3.up) * mCameraOffset;
		Camera.transform.position = CameraTarget.position + newOffset;
		Camera.transform.rotation = Quaternion.LookRotation(-newOffset);
	}

	public void StartScrollingCredits()
	{
		ScrollingCreditText.anchoredPosition = new Vector2(ScrollingCreditText.anchoredPosition.x, mStartingCreditsHeight);
		mCurrentlyScrolling = true;
	}

	public void StopScrollingCredits()
	{
		mCurrentlyScrolling = false;
	}

	public void FromMenuToCredits()
	{
		MainMenu.SetActive(false);
		CreditsMenu.SetActive(true);
		StartScrollingCredits();
	}

	public void FromCreditsToMenu()
	{
		MainMenu.SetActive(true);
		CreditsMenu.SetActive(false);
		StopScrollingCredits();
	}

	public void FromMenuToRoom()
	{
		MainMenu.SetActive(false);
		RoomMenu.SetActive(true);
	}

	public void FromRoomToMenu()
	{
		MainMenu.SetActive(true);
		RoomMenu.SetActive(false);
	}
}
