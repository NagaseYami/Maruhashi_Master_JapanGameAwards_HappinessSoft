﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
	private bool LoadFlag;
	private int Count;
	private AudioSource sound01;        // 効果音 決定

	// Use this for initialization
	void Start()
	{
		LoadFlag = false;

		//AudioSourceコンポーネントを取得し、変数に格納
		AudioSource[] audioSources = GetComponents<AudioSource>();
		sound01 = audioSources[1];

		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update()
	{
		if((Input.GetButtonDown("Fire1") | Input.GetButtonDown("Fire2") | Input.GetButtonDown("Start1") | Input.GetButtonDown("Start2")) & LoadFlag == false)
		{
			FadeManager.Instance.LoadScene("SelectScene", 1.0f);

			// 決定音再生
			sound01.PlayOneShot(sound01.clip);

			LoadFlag = true;
		}

		if(Count >= 600 & LoadFlag == false)
		{
			FadeManager.Instance.LoadScene("OpeningScene", 0.5f);
			LoadFlag = true;
		}
		Count++;

		// エスケープキーが入力されたらアプリを終了する
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}

#if DEBUG
		// シーンのリセット
		if (Input.GetKeyDown(KeyCode.P))
		{
			// シーンを読み込む
			SceneManager.LoadScene("TitleScene");
		}
#endif
	}
}
