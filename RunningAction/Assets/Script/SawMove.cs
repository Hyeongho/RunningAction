using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMove : MonoBehaviour
{
    public string dic;

    public float size;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash(dic, size, "speed", speed, "easeType", iTween.EaseType.easeInOutSine, "looptype", iTween.LoopType.pingPong));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, 1000 * Time.deltaTime);
    }
}
