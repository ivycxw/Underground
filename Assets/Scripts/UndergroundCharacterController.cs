using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
[RequireComponent(typeof(Animator))]
public class UndergroundCharacterController : MonoBehaviour
{
	private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
	private Transform m_Cam;                  // A reference to the main camera in the scenes transform
	private Vector3 m_CamForward;             // The current forward direction of the camera
	private Vector3 m_Move;
	private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
	private Animator m_Animator;

        
	void Start()
	{
		// get the transform of the main camera
		if (Camera.main != null)
		{
			m_Cam = Camera.main.transform;
		}
		else
		{
			Debug.LogWarning(
				"Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
			// we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
		}

		// get the third person character ( this should never be null due to require component )
		m_Character = GetComponent<ThirdPersonCharacter>();
		m_Animator = GetComponent<Animator>();
	}


	void Update()
	{
		if (!m_Jump)
		{
			m_Jump = ControlInputWrapper.GetButtonDown(ControlInputWrapper.Buttons.Y) || Input.GetButtonDown("Jump");
		}
	}


	// Fixed update is called in sync with physics
	void FixedUpdate()
	{
		// read inputs
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		m_Animator.SetBool("Attacking", ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.X) || Input.GetButton("Attacking") && m_Character);

		// calculate move direction to pass to character
		if (m_Cam != null)
		{
			// calculate camera relative direction to move:
			m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
			m_Move = v*m_CamForward + h*m_Cam.right;
		}
		else
		{
			// we use world-relative directions in the case of no main camera
			m_Move = v*Vector3.forward + h*Vector3.right;
		}

		// pass all parameters to the character control script
		m_Character.Move(m_Move, false, m_Jump);
		m_Jump = false;
	}
}
