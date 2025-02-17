using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User {
	private int level = 1;
	private int clearLevel = 5;
	private int choiceLevel = 1;

	public int getChoiseLevel() {
		return this.choiceLevel;
	}

	public void setChoiseLevel(int updateLevel) {
		this.choiceLevel = updateLevel;
	}

	public int getLevel() {
		return this.level;
	}

	public int getClearLevel() {
		return this.clearLevel;
	}

	public void levelUp() {
		++this.clearLevel;
		this.level = this.clearLevel + 1;
	}
}

public class UserControl {
	private static User instance;

	public static User get() {
		if (null == instance) {
			instance = new User();
		}

		return instance;
	}
}
