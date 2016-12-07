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
using System.Collections.Generic;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ThirdPersonCharacter))]
[RequireComponent(typeof(Animator))]
public class UndergroundCharacter : MonoBehaviour
{
	public float MaxHealth = 100.0f;
	public float CameraSmoothingFactor = 5f;
	public float RespawnTime = 2.0f;

	private ThirdPersonCharacter m_Character;
	private Transform m_CamTransform;
	private Vector3 m_CamForward;
	private Vector3 m_Move;
	private bool m_Jump;
	private Animator m_Animator;
	private List<GameObject> m_PotentialHitObjects;
	private Vector3 m_CamOffset;
	private float m_Health;
	private bool m_Dead;
	private Grayscale m_DeadEffect;

        
	void Start()
	{
		// Get the camera transform for camera relative controls
		if (Camera.main != null)
		{
			m_CamTransform = Camera.main.transform;
			m_CamOffset = m_CamTransform.position - transform.position;
			m_DeadEffect = Camera.main.GetComponent<Grayscale>();
			if (m_DeadEffect != null)
			{
				m_DeadEffect.enabled = false;
			}
		}
		else
		{
			Debug.LogWarning("Warning: No main camera found. Underground character needs a Camera tagged \"MainCamera\" for camera-relative controls.");
		}

		// Get the ThirdPersonCharacter and Animator controls need for the character
		m_Character = GetComponent<ThirdPersonCharacter>();
		m_Animator = GetComponent<Animator>();

		// Set up the list of objects that should potentially be hit
		m_PotentialHitObjects = new List<GameObject>();

		// Set up the current health based on the max health
		m_Health = MaxHealth;
		m_Dead = false;
	}

	void Update()
	{
		if (!m_Dead)
		{
			// Check input for jumping
			if (!m_Jump)
			{
				m_Jump = ControlInputWrapper.GetButtonDown(ControlInputWrapper.Buttons.Y) || Input.GetButtonDown("Jump");
			}

			// Check to see if the user has requested to attack and set it in the animator
			m_Animator.SetBool("Attacking", ControlInputWrapper.GetButton(ControlInputWrapper.Buttons.X) || Input.GetButton("Attacking"));

			// If we are in the "hit" part of the Hit animation, check to see if we are colliding with anything
			if (m_Animator.GetFloat("Hit") > 0.0f)
			{
				foreach (GameObject go in m_PotentialHitObjects)
				{
					Enemy e = go.GetComponent<Enemy>();
					if (e != null)
					{
						e.TakeDamage(25);
					}
				}
				// We've hit objects now, so clear the potentials list so that objects don't get hit multiple times in a single attack
				m_PotentialHitObjects.Clear();
			}
		}
	}

	void FixedUpdate()
	{
		// Grab the movement axes and our movement
		float h = (!m_Dead) ? Input.GetAxis("Horizontal") : 0.0f;;
		float v = (!m_Dead) ? Input.GetAxis("Vertical") : 0.0f;

		// Taken from the third person user controller, calculates relative camera movement
		if (m_CamTransform != null)
		{
			m_CamForward = Vector3.Scale(m_CamTransform.forward, new Vector3(1, 0, 1)).normalized;
			m_Move = v * m_CamForward + h * m_CamTransform.right;
		}
		else
		{
			m_Move = v * Vector3.forward + h * Vector3.right;
		}

		m_Character.Move(m_Move, false, m_Jump);
		m_Jump = false;

		// Update our camera tracking
		Vector3 targetCamPos = transform.position + m_CamOffset;
        m_CamTransform.position = Vector3.Lerp(m_CamTransform.position, targetCamPos, CameraSmoothingFactor * Time.deltaTime);
		m_CamTransform.rotation = Quaternion.LookRotation(transform.position - m_CamTransform.position);
	}

	void OnTriggerEnter(Collider other)
	{
		// Add the hit object to the list of potential hit objects
		if (!m_PotentialHitObjects.Contains(other.gameObject))
		{
			m_PotentialHitObjects.Add(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other)
	{
		// Remove the hit object from the list of potential hit objects
		if (m_PotentialHitObjects.Contains(other.gameObject))
		{
			m_PotentialHitObjects.Remove(other.gameObject);
		}
	}

	// Called to damage the character
	public void TakeDamage(float DamageAmount)
	{
		if (!m_Dead)
		{
			m_Health -= DamageAmount;
			Debug.Log ("Damaged by " + DamageAmount);
			if (m_Health <= 0.0f)
			{
				Died();
			}
		}
	}

	// Added by Sangmin to add HP
	public void IncreaseHP(float hp) {
		if (!m_Dead) {
			m_Health += hp;
			Debug.Log ("HP is increased by " + hp);
			if (m_Health >= MaxHealth) {
				m_Health = MaxHealth;
			}
		}
	}
		
	// Added by Sangmin to take HP from Particle
	void OnParticleCollision(GameObject other) {
		if (other.CompareTag ("DragonParticle")) {
			TakeDamage (1);
		}
	}

	// Called when the character dies
	private void Died()
	{
		m_Dead = true;
		if (m_DeadEffect != null)
		{
			m_DeadEffect.enabled = true;
		}
		m_Animator.SetTrigger("Died");
		Invoke("Respawn", RespawnTime);
	}

	// Called after a timer to respawn the character at the last checkpoint
	private void Respawn()
	{
		SceneManager.LoadScene("Scenes/Game Level");
//		m_Dead = false;
//		m_Health = MaxHealth;
//		if (m_DeadEffect != null)
//		{
//			m_DeadEffect.enabled = false;
//		}
//		m_Animator.SetTrigger("Respawn");
	}
}