using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float speed;
    public Image FadeImage;

    private void Awake()
    {
        var obj = FindObjectsOfType<GameManager>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
		if (SceneManager.GetActiveScene().name == "Title")
		{
			if (Input.anyKey)
			{
                iTween.ValueTo(gameObject, iTween.Hash("from", 0.0f, "to", 1.0f, "time", speed, "easetype", "linear", "onUpdate", "FadeInUpdate", "oncomplete", "LoadScene"));
            }
		}

		else
		{

		}
    }

    void FadeInUpdate(float fAlpha)
	{
		if (SceneManager.GetActiveScene().name == "Title")
		{
            Color color;

            color.r = FadeImage.color.r;
            color.g = FadeImage.color.g;
            color.b = FadeImage.color.b;
            color.a = fAlpha;

            FadeImage.color = color;
        }
    }

    void LoadScene()
	{
        SceneManager.LoadScene("Temporary");
    }
}
