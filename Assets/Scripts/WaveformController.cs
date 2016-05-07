using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets._2D;
public class WaveformController : MonoBehaviour
{

    public int playerLayer = 8;
    public int passableLayer = 9;
    public int particleLayer = 10;

    PlatformerCharacter2D character;

    Vector2 waveformLastPosition = Vector2.zero; // Character's last position to "freeze" the radius

    public double WaveFormEnergy = 5;
    public double WaveFormDegenerate = 2;
    public double WaveFormRegenerate = 2;
    public double WaveFormMax = 5;
    public double WaveFormMin = 1;


    // Use this for initialization
    void Start()
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
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1") && WaveFormEnergy > 4)
        {
            
            IsOn();
        }
        else if (CrossPlatformInputManager.GetButtonUp("Fire1"))
        {
            IsOff();
        }
        if (Waveform.active)
        {
            //Debug.Log(WaveFormEnergy);
            WaveFormEnergy -= WaveFormDegenerate * Time.deltaTime;
            if (WaveFormEnergy < WaveFormMin)
            {
                IsOff();
            }
        }
        else if (WaveFormEnergy < WaveFormMax)
        {
            WaveFormEnergy += WaveFormRegenerate * Time.deltaTime;
        }

        // Particle radius
        if (!Waveform.active)
        {
            // Only find radius component in "if" statements so we don't load it each update
            Transform radius = transform.Find("radius");
            radius.position = transform.position; //radius follows player until they go in waveform
            radius.GetComponent<SpriteRenderer>().enabled = false; // don't show radius when not in waveform
            waveformLastPosition = radius.position;
            radius.transform.localScale = new Vector2(2, 2); // default scale
        }
        else
        {
            Transform radius = transform.Find("radius");
            radius.GetComponent<SpriteRenderer>().enabled = true;
            radius.position = waveformLastPosition;

            float speed = (this.GetComponent<PlatformerCharacter2D>().GetComponent<Rigidbody2D>().velocity.magnitude + 1.0f)*2;
            radius.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, 0);
        }
    }
}
