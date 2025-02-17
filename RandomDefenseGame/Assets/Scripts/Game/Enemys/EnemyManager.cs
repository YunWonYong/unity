using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
	private Dictionary<int, GameObject> enemyPrefabs = new Dictionary<int, GameObject>();
	private float enemyGenCooltime = 1f;
	private int genIndex = 0;

	private List<Dictionary<int, int>> enemyList = null;

	public void setEnemyList(List<Dictionary<int, int>> enemyList) {
		this.enemyList = enemyList;
	}

	public void next() {
		if (this.enemyList.Count == this.genIndex) {
			Debug.Log("last round.");
			return;
		}
		Dictionary<int, int> info = this.enemyList[this.genIndex];
		Debug.Log("current: " + this.genIndex);
		Dictionary<int, int>.Enumerator enumerator = info.GetEnumerator();
		while (enumerator.MoveNext()) {
			KeyValuePair<int, int> kvp = enumerator.Current;
			int monsterType = kvp.Key;
			int monsterGenCnt = kvp.Value;

			GameObject prefab = getEnemyPrefab(monsterType);
			genEnemys(prefab, monsterGenCnt);

		}
		++this.genIndex;
		Debug.Log("next: " +  this.genIndex);
	}

	GameObject getEnemyPrefab(int monsterType) {
		if (enemyPrefabs.ContainsKey(monsterType)) {
			return enemyPrefabs[monsterType];
		}

		GameObject prefab = Resources.Load<GameObject>("Monsters/" + monsterType);
		enemyPrefabs[monsterType] = prefab;
		return prefab;
	}

	void genEnemys(GameObject prefab, int genCnt) {
		StartCoroutine(genEnemy(prefab, genCnt));
	}

	IEnumerator genEnemy(GameObject monsterPrefab, int genCnt) {
		int i = 0;
		while (i < genCnt) {
			Instantiate(monsterPrefab, getInitPosition(), Quaternion.identity);
			yield return new WaitForSeconds(enemyGenCooltime);
			++i;
		}
	}

	Vector3 getInitPosition() {
		return new Vector3(Random.Range (-2.25f, 2.25f), 5.5f, 50);
	}
}
