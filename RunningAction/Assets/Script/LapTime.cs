using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LapTime : MonoBehaviour
{
    public float second;
    public int minute;
    public int hour;

    PlayerControl player;

    TextMeshProUGUI TMPtext;

    // Start is called before the first frame update
    void Start()
    {
        second = 0;
        minute = 0;
        hour = 0;

        TMPtext = this.gameObject.GetComponent<TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
		if (!player.isFinsh)
		{
            Timer();
        }      
    }

    void Timer()
	{
        second += Time.deltaTime;

        TMPtext.text = string.Format("{0:D2} : {1:D2} : {2:D2}", hour, minute, (int)second);

        if (second > 60)
        {
            second = 0;
            minute++;

            if (minute > 60)
            {
                minute = 0;
                hour++;
            }

        }
    }
}
