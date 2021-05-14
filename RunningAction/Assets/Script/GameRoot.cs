using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameRoot : MonoBehaviour
{
    public float step_timer;

    private float speed;

    PlayerControl player;

    DeathCount death;

    TextMeshProUGUI TMPtext;

    bool isfade = true;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

        death = GameObject.Find("DeathCount").GetComponent<DeathCount>();

        TMPtext = GameObject.Find("Die").GetComponent<TextMeshProUGUI>();

        speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
		if (this.player.IsPlayEnd())
		{
			if (isfade)
			{
                isfade = false;

                iTween.ValueTo(gameObject, iTween.Hash("from", 0.0f, "to", 1.0f, "time", speed, "easetype", "linear", "onUpdate", "FadeInUpdate"));
            }
         
            if (Input.GetKey(KeyCode.R))
			{
                death.count++;

                ResetDie();

                SceneManager.LoadScene("Temporary");
            }            
		}
    }

    void FadeInUpdate(float fAlpha)
    {
        Color color;

        color.r = TMPtext.color.r;
        color.g = TMPtext.color.g;
        color.b = TMPtext.color.b;
        color.a = fAlpha;

        TMPtext.color = color;
    }

    void ResetDie()
	{
        Color color;

        color.r = TMPtext.color.r;
        color.g = TMPtext.color.g;
        color.b = TMPtext.color.b;
        color.a = 0.0f;

        TMPtext.color = color;
    }
}
