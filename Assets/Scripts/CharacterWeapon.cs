using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Animator))]
public class CharacterWeapon : MonoBehaviour
{
	private Animator m_Animator;
	private List<GameObject> m_CollidingObjects;

	void Start ()
	{
		m_Animator = GetComponent<Animator>();
		m_CollidingObjects = new List<GameObject>();
	}
	
	void Update ()
	{
		if (m_Animator.GetFloat("Hit") > 0.0f)
		{
			foreach (GameObject go in m_CollidingObjects)
			{
				Debug.Log("Hit game object: " + go);
				// TODO: Damage any NPCs that are hit
			}
			m_CollidingObjects.Clear();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (!m_CollidingObjects.Contains(other.gameObject))
		{
			m_CollidingObjects.Add(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (m_CollidingObjects.Contains(other.gameObject))
		{
			m_CollidingObjects.Remove(other.gameObject);
		}
	}
}