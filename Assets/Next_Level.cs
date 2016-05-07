using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Next_Level : MonoBehaviour {
    //Portal stuff, for finding out if the player has a key and sending them to the next level
    private PlatformerCharacter2D Player;
	// Use this for initialization
	void Start () {
	
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") //Checks if the player is hitting the portal
        {
            Player = other.GetComponent<PlatformerCharacter2D>();
            if (Player.HasKey()) //Checks if the player has a key
            {
                //Put the effect to go to the next level here
                Debug.Log("You won, go home");
            }
        }
    }
// Update is called once per frame
void Update () {
	
	}
}
