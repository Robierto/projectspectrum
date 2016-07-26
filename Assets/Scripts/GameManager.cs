using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

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
	
	}
}
