using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadNext()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void restartGame()
    {
        Application.LoadLevel(0);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
