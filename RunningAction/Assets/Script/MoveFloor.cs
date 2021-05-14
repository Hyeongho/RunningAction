using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    GameObject Floor;

    public string Dir;

    public float speed;
    public float size;

    // Start is called before the first frame update
    void Start()
    {
        Floor = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        iTween.MoveTo(gameObject, iTween.Hash(Dir, size, "speed", speed, "easeType", iTween.EaseType.linear, "looptype", iTween.LoopType.pingPong));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
