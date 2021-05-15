using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndTime : MonoBehaviour
{
    TextMeshProUGUI TMPtext;

    PlayerControl player;

    LapTime lapTime;

    // Start is called before the first frame update
    void Start()
    {
        TMPtext = this.gameObject.GetComponent<TextMeshProUGUI>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {      
        if (player.isFinsh)
        {
            TMPtext = this.gameObject.GetComponent<TextMeshProUGUI>();

            TMPtext.text = string.Format("{0:D2} : {1:D2} : {2:D2}", lapTime.hour, lapTime.minute, (int)lapTime.second);
        }
    }
}
