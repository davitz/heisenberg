using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 7.0f;

    void Start() {}

    void Update()
    {

        // Jump
        float vertical = Input.GetAxis("Vertical");
        if (vertical <= 0) vertical = 0.0f; 

        // Apply movement vector with speed to current position
        transform.position += new Vector3(Input.GetAxis("Horizontal"),vertical,0) * Speed * Time.deltaTime;
    }
}
