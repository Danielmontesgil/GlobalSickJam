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


        move.y = vertical;
        move.x = horizontal;

        rb.velocity = move.normalized * speed * delta;
    }

    void Rotation()
    {
        if (vision == null) return;
        if (horizontal > 0)
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 270f));
            vision.transform.localRotation = rotation;
        }else if (horizontal < 0)
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            vision.transform.localRotation = rotation;
        }else if (vertical > 0)
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 0f));
            vision.transform.localRotation = rotation;
        }
        else if (vertical < 0)
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 180f));
            vision.transform.localRotation = rotation;
        }

    }

    void OnAnimator()
    {
        if (anim == null) return;

        anim.SetFloat(StaticsInput.animHorizontal, horizontal);
        anim.SetFloat(StaticsInput.animVertical, vertical);
    }

}
