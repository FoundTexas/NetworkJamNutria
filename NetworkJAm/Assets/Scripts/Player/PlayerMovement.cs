﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Stuff:")]
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform weaponHolder;

    bool facingRight = true;
    Animator animator;
    Rigidbody2D rb2d;
    Vector2 movement,mousePos,lookDir;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Time.timeScale = 0.3f;
        }
        else if (Input.GetKeyUp("space"))
        {
            Time.timeScale = 1;
        }
        Animations();
    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        lookDir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (lookDir.x < 0)
        {
            Flip(-1);
        }
        else if (lookDir.x > 0)
        {
            Flip(1);
        }

        if(movement != Vector2.zero)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddRelativeForce(movement * speed);
        }
    }

    public void Flip(int i)
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x = i;
        transform.localScale = Scaler;
        Vector3 Scaler2 = transform.localScale;
        Scaler2.y = i;
        weaponHolder.localScale = Scaler2;
    }

    void Animations()
    {
        //animator.SetFloat("DirectionX", lookDir.x);
        //animator.SetFloat("DirectionY", lookDir.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
