using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEntryControl : MonoBehaviour {
	public Button prevLevelBtn = null;
	public Button nextLevelBtn = null;
	public Button gameStartBtn = null;

	public Text levelPrint = null;

	void Start () {
		prevLevelBtn.onClick.AddListener(prevLevel);
		nextLevelBtn.onClick.AddListener(nextLevel);
		gameStartBtn.onClick.AddListener(gameStart);
		printLevel();
		toggleLevelMoveBtn();
	}

	void prevLevel() {
		User user = UserControl.get();
		int level = user.getChoiseLevel();
		--level;
		if (level == 0) {
			return;
		}

		user.setChoiseLevel(level);
		printLevel();
		toggleLevelMoveBtn();
	}

	void nextLevel() {
		User user = UserControl.get();
		int level = user.getChoiseLevel();
		int clearLevel = user.getClearLevel();
		++level;
		if (level == clearLevel + 2) {
			return;
		}

		user.setChoiseLevel(level);
		printLevel();
		toggleLevelMoveBtn();
	}

	void printLevel() {
		levelPrint.text = UserControl.get().getChoiseLevel().ToString();
	}

	void toggleLevelMoveBtn() {
		User user = UserControl.get();
		int level = user.getChoiseLevel();
		int clearLevel = user.getClearLevel();
		nextLevelBtn.gameObject.SetActive(level < clearLevel + 1);
		prevLevelBtn.gameObject.SetActive(1 < level);
	}

	void gameStart() {
		SceneManager.LoadScene("GameScene");
	}
}
