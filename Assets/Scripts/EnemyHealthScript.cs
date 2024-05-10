using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
	public HealthBar healthbar;
	public static int currentHealth;
	public int MaxHealth = 3;

	void Start()
	{
		healthbar.SetMaxHealth(MaxHealth);
		currentHealth = MaxHealth;
		healthbar.SetHealth(currentHealth);
	}

	void Update()
	{
		while(true)
		{
			StartCoroutine(wait());
			currentHealth--;
			healthbar.SetHealth(currentHealth);
		}
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds(2f);
	}
}

