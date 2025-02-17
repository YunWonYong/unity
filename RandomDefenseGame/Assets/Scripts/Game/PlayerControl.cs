using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public GameObject prefab = null;

	private float baseCoolTime = 5.0f;
	private float nextTime = 0.0f;
	public GameObject bullet = null;

	void Update () {
		if (Time.time > nextTime) {
			GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
			int i = 0;
			int len = enemyList.Length;
			if (len == 0) {
				return;
			}
			float min = 9999.0f;
			int enemyIndex = 0;
			while (i < len) {
				GameObject enemy = enemyList[i];
				float dist = Vector3.Distance(enemy.transform.position, prefab.transform.position);
				if (min > dist) {
					min = dist;
					enemyIndex = i;
				}
				++i;
			}

			nextTime = Time.time + baseCoolTime;
			GameObject skillObj = Instantiate(bullet, prefab.transform.position, Quaternion.identity);
			SkillInterface skill = skillObj.GetComponent<SkillInterface>();
			skill.setTargetEnemy(enemyList[enemyIndex]);

		}
	}
}
