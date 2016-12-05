using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour
{
	[Range(0.0f, 1.0f)]
	public float DamagePercentage;

	void OnCollisionEnter(Collision collision)
	{
		UndergroundCharacter collidingCharacter = collision.gameObject.GetComponent<UndergroundCharacter>();
		if (collidingCharacter != null)
		{
			collidingCharacter.TakeDamage(collidingCharacter.MaxHealth * DamagePercentage);
		}
		Enemy collidingEnemy = collision.gameObject.GetComponent<Enemy>();
		if (collidingEnemy != null)
		{
			collidingEnemy.TakeDamage(100);
		}
	}
}
