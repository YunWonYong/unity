using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallControl : MonoBehaviour {
	public Slider hpbar = null;
	private float HP = 3000.0f;
	private float hp = 3000.0f;

	public void attack(float damage) {
		if (hp <= 0) {
			return;
		}

		hp -= damage;
		Debug.Log(hp / HP);
		hpbar.value = hp / HP;

		if (hp <= 0) {
			//[TODO] Game over
		}
	}
}
