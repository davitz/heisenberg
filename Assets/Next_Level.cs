using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Next_Level : MonoBehaviour {
    //Portal stuff, for finding out if the player has a key and sending them to the next level
    private PlatformerCharacter2D Player;
    private GameObject MyGO;
    private bool KeyIsFound;

    // Use this for initialization
    void Start ()
    {
        MyGO = GameObject.FindWithTag("Player"); //We can get a reference to the player going now for the animation
        Player = MyGO.GetComponent<PlatformerCharacter2D>();
    }
    //The portal teleport to new level check
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") //Checks if the player is hitting the portal
        {
            if (KeyIsFound) //Checks if the player has a key
            {
                //Put the effect to go to the next level here
                Debug.Log("You won, go home");
            }
        }
    }
// Update is called once per frame
    void Update ()
    {
        if (Player.HasKey() && !KeyIsFound) //Will trigger once, and will flip the animation for the portal from locked to open when it is ready
        {
            Debug.Log("Key is found");
            KeyIsFound = true;
        }
	}
}
