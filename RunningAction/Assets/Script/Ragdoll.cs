using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public GameObject charObj;
    public GameObject ragdollObj;

    PlayerControl player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
		if (player.IsPlayEnd())
		{
            GhangeRagdoll();
        }
    }

    public void GhangeRagdoll()
	{
        charObj.SetActive(false);
        ragdollObj.SetActive(true);
	}
}
