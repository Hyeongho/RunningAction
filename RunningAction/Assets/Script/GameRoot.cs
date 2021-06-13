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

    bool isKey;

    public AudioSource DieSource;
    public AudioClip DieClip;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player").GetComponent<PlayerControl>();

        death = GameObject.Find("DeathCount").GetComponent<DeathCount>();

        speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        TMPtext = GameObject.Find("Die").GetComponent<TextMeshProUGUI>();

        if (this.player.IsPlayEnd())
		{
			if (isfade)
			{
                isfade = false;

                DieSound();

                iTween.ValueTo(gameObject, iTween.Hash("from", 0.0f, "to", 1.0f, "time", speed, "easetype", "linear", "onUpdate", "FadeInUpdate", "oncomplete", "IsFade"));
            }
         
            if (Input.GetKey(KeyCode.R) && isKey)
			{
                death.count++;

                player.isFinsh = false;

                ResetDie();

                SceneManager.LoadScene("Temporary");
            }            
		}

		else
		{
			if (Input.GetKey(KeyCode.R) && isKey)
			{
                player.isFinsh = false;

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

    void IsFade()
	{
        isKey = true;
    }

    public void DieSound()
	{
        DieSource.PlayOneShot(DieClip);
	}
}
