using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    private float speed;

    public PlayerStats playerStats;

    public float horizontal;
    public float vertical;

    private Animator anim;
    private Rigidbody2D rb;

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
    }

    void Move()
    {
        horizontal = Input.GetAxis(StaticsInput.Horizontal);
        vertical = Input.GetAxis(StaticsInput.Vertical);

        move.x = horizontal;
        move.y = vertical;

        rb.velocity = move.normalized * speed * delta;
    }

    void Update () {

        delta = Time.deltaTime;

	}

}
