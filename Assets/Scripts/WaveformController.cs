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

    // Use this for initialization
    void Start()
    {
        character = GetComponent<PlatformerCharacter2D>();
        Waveform.active = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (CrossPlatformInputManager.GetAxis("Fire2") == -1)
        {
            Waveform.active = true;
            character.EnterWaveform();
            Physics2D.IgnoreLayerCollision(playerLayer, passableLayer, true);
            Physics2D.IgnoreLayerCollision(playerLayer, particleLayer, true);
            Physics2D.IgnoreLayerCollision(particleLayer, passableLayer, true);

        }
        else if (CrossPlatformInputManager.GetAxis("Fire2") != -1)
        {
            Physics2D.IgnoreLayerCollision(playerLayer, passableLayer, false);
            Physics2D.IgnoreLayerCollision(playerLayer, particleLayer, false);
            Physics2D.IgnoreLayerCollision(particleLayer, passableLayer, false);

            Waveform.active = false;
            character.ExitWaveform();
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

            float speed = (this.GetComponent<PlatformerCharacter2D>().GetComponent<Rigidbody2D>().velocity.magnitude + 1.0f) * 2.0f; // why do we multiply by 2? i don't know stop asking questions
            radius.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, 0);
        }

    }
}
