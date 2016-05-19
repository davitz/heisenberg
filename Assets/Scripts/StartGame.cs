using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (CrossPlatformInputManager.GetButtonDown("Submit"))
        {
            Application.LoadLevel(1);
        }

    }
}
