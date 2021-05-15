using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour
{
	PlayerControl player;

	DeathCount count;
	LapTime lapTime;

	public GameObject panel;

	TextMeshProUGUI TMP1;
	TextMeshProUGUI TMP2;

	private void Awake()
	{
        var obj = FindObjectsOfType<UI_Script>();

		if (obj.Length == 1)
		{
            DontDestroyOnLoad(this.gameObject);
        }

		else
		{
            Destroy(this.gameObject);
		}    
    }

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

		lapTime = GameObject.Find("Timer").GetComponent<LapTime>();
		count = GameObject.Find("DeathCount").GetComponent<DeathCount>();
	}

	void Update()
	{
		if (player.isFinsh)
		{
			panel.SetActive(true);
		}

		else
		{
			panel.SetActive(false);
		}
	}

	public void OnReStart()
	{
		player.isFinsh = false;

		lapTime.second = 0;
		lapTime.minute = 0;
		lapTime.hour = 0;

		count.count = 0;

		SceneManager.LoadScene("Temporary");
	}
}
