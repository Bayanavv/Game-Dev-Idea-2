﻿
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15f;

    private Rigidbody2D rb;
    public float mapWidth = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   void FixedUpdate ()//running on a fixed timer
    {
        /*moving left and right and all ways when doing movment multiply with Time.fixedDeltaTime becouse we insie
         od fixedUpdate with is the amount of time passed since our last fixed update was called and there for
         it will make it independet on whatever are fixedDeltaTime  its running and then we will have a speed veriable*/
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        

        Vector2 newPosition = rb.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

        rb.MovePosition(newPosition);

    }
    void OnCollisionEnter2D ()
    {
        FindObjectOfType<GameManager>().EndGame();
    }
}
