using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathCount : MonoBehaviour
{
    TextMeshProUGUI TMPtext;
    PlayerControl player;

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        TMPtext = this.gameObject.GetComponent<TextMeshProUGUI>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TMPtext.text = "Death: " + count.ToString();
    }
}
