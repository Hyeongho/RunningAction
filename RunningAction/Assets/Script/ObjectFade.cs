using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFade : MonoBehaviour
{
    public float speed;

    public float delay;

    public float alpha;

    new Renderer renderer;

    public GameObject floor;

    Color c;

    // Start is called before the first frame update
    void Start()
    {
        alpha = 1.0f;

        renderer = this.gameObject.transform.GetChild(0).GetComponent<Renderer>();

        FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FadeOutUpdate(float _alpha)
	{
        c = renderer.material.color;

        c.a = _alpha;

        renderer.material.color = c;
    }

    void FadeOutComplete()
	{
        floor.SetActive(false);

        c = renderer.material.color;

        c.a = 0;

        renderer.material.color = c;

        Invoke("FadeIn", delay);
    }

    void FadeInComplete()
	{
        c = renderer.material.color;

        c.a = 1.0f;

        renderer.material.color = c;

        FadeOut();
    }

    void FadeOut()
	{
        iTween.ValueTo(gameObject, iTween.Hash("from", 1.0f, "to", 0.0f, "time", speed, "delay", delay, "easetype", iTween.EaseType.linear, "onUpdate", "FadeOutUpdate", "oncomplete", "FadeOutComplete"));
	}

    void FadeIn()
	{
        floor.SetActive(true);

        iTween.ValueTo(gameObject, iTween.Hash("from", 0.0f, "to", 1.0f, "time", speed, "easetype", iTween.EaseType.linear, "onUpdate", "FadeOutUpdate", "oncomplete", "FadeInComplete"));
    }
}
