using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	public Text debugHPText;
	public Text debugAmmoText;
	public GameObject player;
	public Transform spawnPoint;
	public PlayerShoot shootManager;
	public Slider HPSlider;
	public Slider AmmoSlider;

	[SerializeField]
	private int maxHealth = 100;

	private int score = 0;
	private int currentHealth;

	void Awake() 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		currentHealth = maxHealth;
	}

	void Update() 
	{
		debugHPText.text = "HP: " + currentHealth + "/" + maxHealth;
		HPSlider.value = (1.0f / maxHealth) * currentHealth;
		debugAmmoText.text = "AMMO: " + shootManager.ammo;
		AmmoSlider.value = (1.0f / shootManager.maxAmmo) * shootManager.ammo;

		if (currentHealth <= 0)
			Die ();

		if (Input.GetKeyDown (KeyCode.K))
			currentHealth -= 1;
	}

	void Die()
	{
		Debug.Log ("YOU HAVE DIED!!!");
		currentHealth = maxHealth;
		player.transform.position = spawnPoint.position;
	}
}
