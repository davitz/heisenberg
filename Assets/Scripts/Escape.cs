using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Escape : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }

    }
}
