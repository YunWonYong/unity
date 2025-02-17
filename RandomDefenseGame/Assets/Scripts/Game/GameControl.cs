using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
	public GameObject enemyManagerObj = null;
	public Image dimmed = null;

	private int round = 0;
	private int lastRound = 20;
	private float nextRoundCooltime = 0.0f;
	private readonly float roundCooltime = 10.0f;

	private List<Dictionary<int, int>> enemyListByRound = null;
	// Use this for initialization
	void Start () {
		dimmed.gameObject.SetActive(false);
		// [TODO] Scene 변경 시 round의 정보를 받아야함.
		// , == round
		// # == monther type
		// : == monther id and gen count
		string enemyInfo = "1:5,1:5#2:1,1:4#2:2,1:3#2:3,1:5#2:4,1:6#2:6,1:3#2:4#3:2,1:2#2:6#3:5";
		initEnemyList(enemyInfo);
	}

	void Update() {
		float t = Time.time;
		if (nextRoundCooltime > t) {
			return;
		}

		nextRoundCooltime = t + roundCooltime;
		EnemyManager enemyManager = enemyManagerObj.GetComponent<EnemyManager>();
		enemyManager.next();
		++this.round;
	}

	void initEnemyList(string enemyStrInfo) {
		string[] rounds = enemyStrInfo.Split(',');
		enemyListByRound = new List<Dictionary<int, int>>();
		Dictionary<int, int> dict = new Dictionary<int, int>();
		for (int i = 0; i < rounds.Length; ++i) {
			string enemys = rounds[i];
			foreach (string enemy in enemys.Split('#')) {
				string[] info = enemy.Split(':');
				string enemyIdStr = info[0];
				string enemyGenCntStr = info[1];
				int enemyId = int.Parse(enemyIdStr);
				int enemyGenCnt = int.Parse(enemyGenCntStr);
				Debug.Log(i + " round. " + "enemyId: " +enemyId + " genCount: " + enemyGenCnt);
				dict.Add(enemyId, enemyGenCnt);
			}
			enemyListByRound.Add(dict);
			dict = new Dictionary<int, int>();
		}

		this.lastRound = enemyListByRound.Count;
		EnemyManager enemyManager = enemyManagerObj.GetComponent<EnemyManager>();
		enemyManager.setEnemyList(enemyListByRound);
	}

	public int getRound() {
		return this.round;
	}

	public int getLastRound() {
		return this.lastRound;
	}
}
