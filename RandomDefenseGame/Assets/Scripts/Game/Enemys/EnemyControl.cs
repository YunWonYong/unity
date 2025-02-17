using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
	private int hp = 10;
	private float moveSeed = 0.4f;

	private bool isMove = true;
	private bool isAttack = false;

	public float attackPower = 30.0f;
	public float attackCoolTime = 0.1f;
	private float nextAttackCooltime = 0.0f;

	void Update () {
		if (isMove) {
			gameObject.transform.Translate(Time.deltaTime * moveSeed * -Vector3.up);
		}

		if (isAttack) {
			float t = Time.time;
			if (nextAttackCooltime < t) {
				nextAttackCooltime = t + attackCoolTime;
				GameObject wallObj = GameObject.FindGameObjectWithTag("Wall");
				WallControl wall = wallObj.GetComponent<WallControl>();
				wall.attack(attackPower);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Wall") {
			this.isMove = false;
			this.isAttack = true;
		} else if (other.tag == "Skill") {
			SkillInterface skill = other.GetComponent<SkillInterface>();
			int damage = skill.getDamage();
			Destroy(other.gameObject);
			this.hp -= damage;
			if (this.hp <= 0) {
				Destroy(gameObject);
			}
		}
	}
}
