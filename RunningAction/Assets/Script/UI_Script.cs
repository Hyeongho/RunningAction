using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Script : MonoBehaviour
{
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

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
