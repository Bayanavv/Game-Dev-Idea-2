
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15f;
    private Rigidbody2D rb;
    public float mapWidth = 5f;//choose how wide our map will be

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
        
        /*vector2 2 demensial that cheking for colisions and moving to a new position 
         usfull thing is the position that we want to move to is our current position plus some
         x value so we want to move to our current position either bit to the right or a bit to 
         left our current position is called rb.position*/
        Vector2 newPosition = rb.position + Vector2.right * x;

        /*clamping the value of the width of the map or other world limiting the value between so
         it doesnt go above the width ussing Mathf.Clamp with take in a value that it should limit 
         then a minum vakue and a maximum value */
        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

        /* RigitBody2D.MovePosition is basicaly moving the object to certain position and cheking for
         for collisions along the way*/
        rb.MovePosition(newPosition);

    }

    /*must be Exacly the same becose its a callBack Function means unity decidet to cod for us and its call when eve we hit some thing useing 
    our 2D Colider */
    void OnCollisionEnter2D ()
    {
        FindObjectOfType<GameManager>().EndGame();
    }
}
