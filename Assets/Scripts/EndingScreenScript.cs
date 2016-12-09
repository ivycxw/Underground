using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScreenScript : MonoBehaviour {
	private AudioSource source;
	public ParticleSystem particle;
	public AudioClip movingSound;

	public Text WinLabel;
	public Text HealthLabel;
	public Slider HealthSlider;

	void Start () {
		source = GetComponent<AudioSource> ();
		WinLabel.enabled = false;
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			if (PlayerItemManager.r4_num_keys >= 1) {
				source.PlayOneShot (movingSound);
				particle.Stop ();
				// Ending Screen should be hooked up here
				WinLabel.enabled = true;
				Invoke("EndGame", 10.0f);
			}
		}
	}

	void EndGame() {
		SceneManager.LoadScene("Scenes/Menu");
	}
}
