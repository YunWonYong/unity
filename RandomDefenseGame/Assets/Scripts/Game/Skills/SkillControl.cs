using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillControl : MonoBehaviour, SkillInterface {
	public GameObject prefab = null;
	private GameObject target = null;

	void Update () {
		if (target == null) {
			return;
		}

		float seed = getSpeed ();
		Vector3 targetPosition = target.transform.position - prefab.transform.position;
		prefab.transform.Translate(Time.deltaTime * seed * targetPosition.normalized);
	}

	public int getDamage() {
		return 10;	
	}

	public float getSpeed() {
		return 5.0f;
	}

	public void setTargetEnemy(GameObject t) {
		target = t;
	}
}
