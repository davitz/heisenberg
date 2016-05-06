using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 7.0f; // Player speed
    public int MaxJumpCount = 1; // Maximum consecutive jumps (2 = double jump, 3 = triple jump)
    public float JumpForce = 5.0f; // Player jump force (how high can he go?????????????)

    private int jumps = 0; // Current jump count, global because we reset in OnCollisionEnter2D

    void Start()
    {
        // nothing, fucko
    }

    void Update()
    {

        // If "space" is pressed, jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Check that we're not like double jumping or whatever
            if (jumps < MaxJumpCount)
            {               
                // Add force to the Y component of the player's rigidbody2D
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                jumps++;
            }
        }
            
        // Apply movement vector with speed to current position
        transform.position += new Vector3(Input.GetAxis("Horizontal"),0,0) * Speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // if we only want jumps to reset on specific objects, that can be added in later
        jumps = 0;
    }
}
