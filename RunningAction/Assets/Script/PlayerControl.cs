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

    bool isLanded;
    bool isColided;
    bool isKey;

    // Start is called before the first frame update
    void Start()
    {
        this.next_step = STEP.Run;

        isLanded = false;
        isColided = false;
        isKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 velocity = this.GetComponent<Rigidbody>().velocity;

        Check_Landed();

        this.step_timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Look = 0 * Vector3.forward + -1 * Vector3.right;

            transform.rotation = Quaternion.LookRotation(Look);

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Look = 0 * Vector3.forward + 1 * Vector3.right;

            transform.rotation = Quaternion.LookRotation(Look);

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
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
                        }
                    }

                    break;
				case STEP.Jump:
					if (this.isLanded)
					{
                        this.next_step = STEP.Run;
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
}
