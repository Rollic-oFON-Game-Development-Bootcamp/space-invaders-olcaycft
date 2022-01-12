using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5f;
    private Vector3 leftEdge;
    private Vector3 rightEdge;

    private void Awake()
    {
        leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
    }

    private void Update()
    {
        PlayerSideMovement();
    }

    private void PlayerSideMovement()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= leftEdge.x)
            {
                var position = transform.position;
                position.x = rightEdge.x;
                transform.position = position;
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= rightEdge.x)
            {
                var position = transform.position;
                position.x = leftEdge.x;
                transform.position = position;
            }
        }
    }
}