using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public enum STEP
	{
        None = -1,
        Run = 0,
        Jump,
        miss,
        num
	};

    Vector3 Look;

    public STEP step = STEP.None;
    public STEP next_step = STEP.None;
    public float step_timer = 0.0f;

    public float jump = 5.5f;
    public float speed = 2.0f;
    public float deceleration = 0.5f;

    public float height = -5.0f;

    public bool isEnd;

    public bool isFinsh;

    public Transform transform1;
    public Transform transform2;
    public Transform transform3;
    public Transform transform4;

    bool isLanded;
    bool isColided;
    bool isKey;

    Animator playerAni;

	private void Awake()
	{
        playerAni = GameObject.Find("Player_Chr").GetComponent<Animator>();

        isLanded = false;
        isColided = false;
        isKey = false;
        isEnd = false;

        isFinsh = false;
    }

	// Start is called before the first frame update
	void Start()
    {    
        this.next_step = STEP.Run;      
    }

    // Update is called once per frame
    void Update()
    {
		if (!IsPlayEnd())
		{
            Move();

			if (Input.GetKey(KeyCode.F1))
			{
                this.gameObject.transform.position = transform1.position;

            }

            if (Input.GetKey(KeyCode.F2))
            {
                this.gameObject.transform.position = transform2.position;
            }

            if (Input.GetKey(KeyCode.F3))
            {
                this.gameObject.transform.position = transform3.position;
            }

            if (Input.GetKey(KeyCode.F4))
            {
                this.gameObject.transform.position = transform4.position;
            }
        }
        
    }

    void Move()
    {
        Vector3 velocity = this.GetComponent<Rigidbody>().velocity;

        Check_Landed();

        switch (this.step)
        {
            case STEP.Run:
            case STEP.Jump:
                if (this.transform.position.y < height)
                {
                    this.next_step = STEP.miss;
                }

                break;
            default:
                break;
        }

        this.step_timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerAni.SetBool("isRun", true);

            Look = 0 * Vector3.forward + -1 * Vector3.right;

            transform.rotation = Quaternion.LookRotation(Look);

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

		else if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
            playerAni.SetBool("isRun", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerAni.SetBool("isRun", true);

            Look = 0 * Vector3.forward + 1 * Vector3.right;

            transform.rotation = Quaternion.LookRotation(Look);

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

		else if (Input.GetKeyUp(KeyCode.RightArrow))
		{
            playerAni.SetBool("isRun", false);
        }

		if (this.next_step == STEP.None)
		{
			switch (this.step)
			{
				case STEP.Run:
                    if (!this.isLanded)
                    {

                    }

                    else
                    {
                        if (Input.GetKeyDown(KeyCode.LeftAlt))
                        {
                            this.next_step = STEP.Jump;

                            playerAni.SetBool("isJump", true);
                        }
                    }

                    break;
				case STEP.Jump:
					if (this.isLanded)
					{
                        this.next_step = STEP.Run;

                        playerAni.SetBool("isJump", false);
                    }
					break;
				default:
					break;
			}
		}

		while (this.next_step != STEP.None)
		{
            this.step = this.next_step;

            this.next_step = STEP.None;

			switch (this.step)
			{
				case STEP.Jump:
                    velocity.y = Mathf.Sqrt(2.0f * 9.8f * jump);

                    this.isKey = false;
					break;
				default:
					break;
			}

            this.step_timer = 0.0f;
		}

		switch (this.step)
		{
			case STEP.Jump:
				do
				{
                    if (!Input.GetKeyDown(KeyCode.LeftAlt))
                    {
                        break;
                    }

                    if (this.isKey)
                    {
                        break;
                    }

                    if (velocity.y <= 0.0f)
                    {
                        break;
                    }

                    velocity.y *= deceleration;

                    this.isKey = true;
                } while (false);
				break;
			default:
				break;
		}

        this.GetComponent<Rigidbody>().velocity = velocity;
	}

    void Check_Landed()
    {
        this.isLanded = false;

		do
		{
            Vector3 s = this.transform.position;
            Vector3 e = s + Vector3.down * 1.0f;

            RaycastHit hit;

			if (!Physics.Linecast(s, e, out hit))
			{
                break;
			}

			if (this.step == STEP.Jump)
			{
				if (this.step_timer < Time.deltaTime * 3.0f)
				{
                    break;
				}
			}

            this.isLanded = true;

		} while (false);
    }

    public bool IsPlayEnd()
	{
        bool ret = false;

        switch (this.step)
		{
			case STEP.miss:
                ret = true;

                break;
			default:
				break;
		}

        return (ret);
    }

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.tag == "Obstacle")
		{
            Debug.Log("tag");

            switch (this.step)
            {
                case STEP.Run:
                case STEP.Jump:
                    this.next_step = STEP.miss;

                    break;
                default:
                    break;
            }
        }
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("End"))
		{
            isFinsh = true;
        }        
    }
}
