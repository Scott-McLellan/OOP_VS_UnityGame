using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;

public class PlayerMovement : MonoBehaviour
{

    

    public float GetDistance(Vector2 a, Vector2 b)
    {
        return Mathf.Sqrt(((a.x - b.x) * (a.x - b.x)) + ((a.y - b.y) * (a.y - b.y)));
    }
    public float moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        Debug.Log(moveInput);

        transform.position += moveInput * moveSpeed * Time.deltaTime;
        
        
    }
}
