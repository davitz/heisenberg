using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets._2D;
public class WaveformController : MonoBehaviour {

    public int playerLayer = 8;
    public int passableLayer = 9;
    public int particleLayer = 10;

    PlatformerCharacter2D character;

    public int WaveFormEnergy = 10;
    public int WaveFormDegenerate = 2;
    public int WaveFormRegenerate = 2;
    public int WaveFormMax = 10;

    // Use this for initialization
    void Start () 
    {
        character = GetComponent<PlatformerCharacter2D>();
        Waveform.active = false;
	}

    void IsOn()
    {
            Waveform.active = true;
            character.EnterWaveform();
            Physics2D.IgnoreLayerCollision(playerLayer, passableLayer, true);
            Physics2D.IgnoreLayerCollision(playerLayer, particleLayer, true);
            Physics2D.IgnoreLayerCollision(particleLayer, passableLayer, true);
    }

    void IsOff()
    {
        Physics2D.IgnoreLayerCollision(playerLayer, passableLayer, false);
        Physics2D.IgnoreLayerCollision(playerLayer, particleLayer, false);
        Physics2D.IgnoreLayerCollision(particleLayer, passableLayer, false);

        Waveform.active = false;
        character.ExitWaveform();
    }
	// Update is called once per frame
	void Update () 
    {
        if(CrossPlatformInputManager.GetButtonDown("Fire1") && WaveFormEnergy > 4)
        {
            IsOn();
        }
        else if(CrossPlatformInputManager.GetButtonUp("Fire1"))
        {
            IsOff();
        }
        if (Waveform.active)
        {
            WaveFormEnergy -= WaveFormDegenerate;
            if (WaveFormEnergy < 1)
            {
                IsOff();
            }
        }
        else
        {
            WaveFormEnergy += WaveFormRegenerate;
        }
   }
}
