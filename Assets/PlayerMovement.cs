using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;

public class PlayerMovement : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public bool isFacingLeft { get; private set; }

    public float GetDistance(Vector2 a, Vector2 b)
    {
        return Mathf.Sqrt(((a.x - b.x) * (a.x - b.x)) + ((a.y - b.y) * (a.y - b.y)));
    }
    public float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.flipX = true;
            isFacingLeft = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = false;
            isFacingLeft = false;
        }
        
        Vector3 moveInput = new Vector3(0f, 0f, 0f);
        moveInput.x = Input.GetAxisRaw("Horizontal");
        
        moveInput.y = Input.GetAxisRaw("Vertical");

        Debug.Log(moveInput);

        transform.position += moveInput * moveSpeed * Time.deltaTime;
        
        
    }
}
