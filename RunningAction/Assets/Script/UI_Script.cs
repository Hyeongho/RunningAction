using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
}
