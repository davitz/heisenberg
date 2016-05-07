using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets._2D;
public class WaveformController : MonoBehaviour {

    public int playerLayer = 8;
    public int passableLayer = 9;
    public int particleLayer = 10;

    PlatformerCharacter2D character;

	// Use this for initialization
	void Start () 
    {
        character = GetComponent<PlatformerCharacter2D>();
        Waveform.active = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
       if(CrossPlatformInputManager.GetButtonDown("Fire2"))
       {
           Waveform.active = true;
           character.EnterWaveform();
           Physics2D.IgnoreLayerCollision(playerLayer, passableLayer, true);
           Physics2D.IgnoreLayerCollision(playerLayer, particleLayer, true);
           Physics2D.IgnoreLayerCollision(particleLayer, passableLayer, true);


       }
       else if(CrossPlatformInputManager.GetButtonUp("Fire2"))
       {
           Physics2D.IgnoreLayerCollision(playerLayer, passableLayer, false);
           Physics2D.IgnoreLayerCollision(playerLayer, particleLayer, false);
           Physics2D.IgnoreLayerCollision(particleLayer, passableLayer, false);

           Waveform.active = false;
           character.ExitWaveform();
       }
	
	}
}
