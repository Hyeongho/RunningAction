using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMove : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        iTween.MoveTo(gameObject, iTween.Hash("z", -3.0f, "speed", speed, "easeType", iTween.EaseType.easeInOutSine, "looptype", iTween.LoopType.pingPong));
    }
}
