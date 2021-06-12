using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float speed;
    public Image FadeImage;
    public GameObject Tutorial;

    public GameObject Tutorial2;

    public GameObject TMPro1;
    public GameObject TMPro2;

    public GameObject button1;
    public GameObject button2;

    public List<GameObject> list = new List<GameObject>();

    bool isTutorial;

    int count;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 2.0f;

        count = 0;

        isTutorial = false;

        FadeImage.gameObject.SetActive(false);

        Tutorial.SetActive(false);
        Tutorial2.SetActive(false);
        TMPro2.SetActive(false);

		for (int i = 0; i < list.Count; i++)
		{
            list[i].SetActive(false);
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (SceneManager.GetActiveScene().name == "Title")
		{
			if (Input.anyKey && !isTutorial)
			{
                isTutorial = true;

                Tutorial.SetActive(true);
                button2.SetActive(false);
            }

			if (count == 1)
			{
                TMPro1.SetActive(false);

                Tutorial2.SetActive(true);

                for (int i = 0; i < list.Count; i++)
                {
                    list[i].SetActive(true);
                }
            }

			if (count == 2)
			{
                TMPro2.SetActive(true);

                button1.SetActive(false);

                Tutorial2.SetActive(false);

                button2.SetActive(true);

                for (int i = 0; i < list.Count; i++)
                {
                    list[i].SetActive(false);
                }
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

	public void OnButton()
	{
        count++;
    }

    public void OnStart()
	{
        FadeImage.gameObject.SetActive(true);

        iTween.ValueTo(gameObject, iTween.Hash("from", 0.0f, "to", 1.0f, "time", speed, "easetype", "linear", "onUpdate", "FadeInUpdate", "oncomplete", "LoadScene"));
    }
}
