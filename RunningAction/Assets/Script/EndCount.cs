using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndCount : MonoBehaviour
{
    TextMeshProUGUI TMPtext;

    DeathCount Count;

    PlayerControl player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();       
    }

    // Update is called once per frame
    void Update()
    {
		if (player.isFinsh)
		{
            TMPtext = this.gameObject.GetComponent<TextMeshProUGUI>();

            TMPtext.text = "죽은 횟수	:" + Count.count.ToString();
        }       
    }
}
