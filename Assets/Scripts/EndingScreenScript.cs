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
	}

	void Update () {
		if (PlayerItemManager.r4_num_keys >= 1) {
			source.PlayOneShot (movingSound);
			particle.Stop ();
			// Ending Screen should be hooked up here
			WinLabel.enabled = true;
			HealthLabel.enabled = false;
			HealthSlider.enabled = false;
			Invoke("EndGame", 10.0f);
		}
	}

	void EndGame() {
		SceneManager.LoadScene("Scenes/Menu");
	}
}
