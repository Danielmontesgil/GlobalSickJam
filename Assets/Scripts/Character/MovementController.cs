using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : Vision {

    private float speed;

    public PlayerStats playerStats;

    public float horizontal;
    public float vertical;

    private Animator anim;
    private Rigidbody2D rb;
    public GameObject vision;
   

    float delta;
    Vector2 move;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start () {
        

        speed = playerStats.walkSpeed;
	}

    void FixedUpdate()
    {
        delta = Time.deltaTime;

        Move();
        Rotation();
    }

    void Update()
    {
        delta = Time.deltaTime;

        OnAnimator();
    }

    void Move()
    {
        horizontal = Input.GetAxis(StaticsInput.Horizontal);
        vertical = Input.GetAxis(StaticsInput.Vertical);

        if (Mathf.Abs(horizontal) > .1f)
        move.y = 0;
        else
        move.y = vertical;

        if (Mathf.Abs(vertical) > .1f)
        move.x = 0;
        else
        move.x = horizontal;
        

        rb.velocity = move.normalized * speed * delta;
    }

    void Rotation()
    {
        if (vision == null) return;

        if (horizontal > 0)
        {
            Quaternion rotation = Quaternion.Euler(new Vector2(0, 90f));
            vision.transform.rotation = rotation;
        }else if (horizontal < 0)
        {
            Quaternion rotation = Quaternion.Euler(new Vector2(0, -90f));
            vision.transform.rotation = rotation;
        }else if (vertical > 0)
        {
            Quaternion rotation = Quaternion.Euler(new Vector2(0, 0f));
            vision.transform.rotation = rotation;
        }
        else if (vertical < 0)
        {
            Quaternion rotation = Quaternion.Euler(new Vector2(0, 180f));
            vision.transform.rotation = rotation;
        }

    }

    void OnAnimator()
    {
        if (anim == null) return;

        anim.SetFloat(StaticsInput.animHorizontal, horizontal * delta);
        anim.SetFloat(StaticsInput.animVertical, vertical * delta);
    }

}
