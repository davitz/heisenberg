using UnityEngine;
using System.Collections;

public class EnableObject : MonoBehaviour {
	public bool enabled = false;
	public GameObject enabledObject; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //This is used to find if the player has touched the trigger and to enable selected game object. 
    //spawn something or create popup.
    //might need to add in a disable version (that is why I created enabled so we have the flexiblity to add it in) 
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			if(enabled)
			{
				enabledObject.SetActive(true);
			}
			else
			{
				enabledObject.SetActive(false);
			}
		}
	} 
}
