using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth1 : MonoBehaviour
{
	public int health = 100;

	public GameObject deathEffect;

	public static int BloodI;

	public void TakeDamage(int damage)
	{
		health -= damage;

		StartCoroutine(DamageAnimation());
		
		BloodI = Random.Range(1,1);
		/*
		if (health <= 0)
		{
			Die();
		}
		*/
	}
	void Updata()
    {

	}
	/*
	void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	*/
	IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();
		Bloodspray_Effect.主控.隨機跳血畫面();

		for (int i = 0; i < 3; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
	}
}
