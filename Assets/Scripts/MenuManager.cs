using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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

	public Button MainMenuPlayButton;
	public Button MainMenuMusicButton;
	public Button MainMenuCreditsButton;
	public Button PlayMenuRoom1Button;
	public Button PlayMenuRoom2Button;
	public Button PlayMenuRoom3Button;
	public Button PlayMenuRoom4Button;
	public Button PlayMenuBackButton;
	public Button CreditsMenuBackButton;

	private Vector3 mCameraOffset;
	private float mCurrentRotation;

	private bool mCurrentlyScrolling;
	private float mStartingCreditsHeight;

	private enum EMenuState
	{
		MainMenu,
		PlayMenu,
		CreditsMenu
	};

	private EMenuState mMenuState;


	// Use this for initialization
	void Start ()
	{
		mStartingCreditsHeight = ScrollingCreditText.anchoredPosition.y;
		mCameraOffset = Camera.transform.position - CameraTarget.position;
		Camera.transform.rotation = Quaternion.LookRotation(-mCameraOffset);
		mCurrentRotation = 0.0f;

		mMenuState = EMenuState.MainMenu;

		MainMenu.GetComponent<Canvas>().enabled = true;
		RoomMenu.GetComponent<Canvas>().enabled = false;
		CreditsMenu.GetComponent<Canvas>().enabled = false;

		MainMenuPlayButton.Select();

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

		switch (mMenuState)
		{
			case EMenuState.MainMenu:
				break;
			case EMenuState.PlayMenu:
				if (ControlInputWrapper.GetButtonDown(ControlInputWrapper.Buttons.B))
				{
					FromRoomToMenu();
				}
				break;
			case EMenuState.CreditsMenu:
				if (ControlInputWrapper.GetButtonDown(ControlInputWrapper.Buttons.B))
				{
					FromCreditsToMenu();
				}
				break;
		};
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
		EventSystem.current.SetSelectedGameObject(null);
		MainMenu.GetComponent<Canvas>().enabled = false;
		CreditsMenuBackButton.Select();
		CreditsMenu.GetComponent<Canvas>().enabled = true;
		StartScrollingCredits();
		mMenuState = EMenuState.CreditsMenu;
	}

	public void FromCreditsToMenu()
	{
		EventSystem.current.SetSelectedGameObject(null);
		CreditsMenu.GetComponent<Canvas>().enabled = false;
		MainMenuPlayButton.Select();
		MainMenu.GetComponent<Canvas>().enabled = true;
		StopScrollingCredits();
		mMenuState = EMenuState.MainMenu;
	}

	public void FromMenuToRoom()
	{
		EventSystem.current.SetSelectedGameObject(null);
		mMenuState = EMenuState.PlayMenu;
		MainMenu.GetComponent<Canvas>().enabled = false;
		PlayMenuRoom1Button.Select();
		RoomMenu.GetComponent<Canvas>().enabled = true;
	}

	public void FromRoomToMenu()
	{
		EventSystem.current.SetSelectedGameObject(null);
		RoomMenu.GetComponent<Canvas>().enabled = false;
		MainMenuPlayButton.Select();
		MainMenu.GetComponent<Canvas>().enabled = true;
		mMenuState = EMenuState.MainMenu;
	}

	public void StartGame()
	{
		SceneManager.LoadScene("Scenes/Game Level");
	}
}
