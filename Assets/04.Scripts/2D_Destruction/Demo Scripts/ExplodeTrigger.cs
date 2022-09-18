using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Explodable))]
public class ExplodeTrigger : MonoBehaviour

{

	private Explodable _explodable;

	void Start()
	{
		_explodable = GetComponent<Explodable>();
	}
	/*
	void OnMouseDown()
	{
		_explodable.explode();
		ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
		ef.doExplosion(transform.position);
	}
	*/

	void OnTriggerEnter2D(Collider2D Breaking)
	{
		if (Breaking.gameObject.tag == "Boos")
		{
			_explodable.explode();
			ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
			ef.doExplosion(transform.position);

		}
	}

}
