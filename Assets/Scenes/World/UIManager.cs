using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField] private Text xpText;
	[SerializeField] private Text levelText;
	[SerializeField] private GameObject menu;
	[SerializeField] private AudioClip menuBtnSound;

	private AudioSource audioSource;

	private void Awake() {
		audioSource = GetComponent<AudioSource>();

		Assert.IsNotNull(audioSource);
		Assert.IsNotNull(xpText);
		Assert.IsNotNull(levelText);
		Assert.IsNotNull(menu);
		Assert.IsNotNull(menuBtnSound);
	}

	private void Update() {
		updateLevel();
		updateXP();
	}

	public void updateLevel() {
		levelText.text = GameManager.Instance.CurrentPlayer.Lvl.ToString();
	}

	public void updateXP() {
		xpText.text = GameManager.Instance.CurrentPlayer.Xp +
		              " / " + GameManager.Instance.CurrentPlayer.RequiredXp;
	}

	public void MenuBtnClicked() {
		audioSource.PlayOneShot(menuBtnSound);
//		toggleMenu();
	}

	private void toggleMenu() {
		menu.SetActive(!menu.activeSelf);
	}
}
