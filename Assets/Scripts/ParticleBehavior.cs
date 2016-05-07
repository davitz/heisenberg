using UnityEngine;
using System.Collections;
using System.Collections.Generic;




// possible particle types
public enum ParticleType { A, B, C }

// possible particle spins
public enum ParticleSpin { UP, DOWN }

// possible particle starting directions
public enum ParticleDirection { N, S, W, E, NW, NE, SW, SE }

public class ParticleBehavior : MonoBehaviour
{

    public ParticleType type = ParticleType.A;

    public ParticleSpin spin = ParticleSpin.UP;

    public ParticleDirection startDirection = ParticleDirection.N;

    public float speed = 20.0f;

    public bool visibleInWaveForm = false;

    private Rigidbody2D rigidBody;

    private bool waveForm = false;

    private MeshRenderer renderer;

    private GameObject effectContainer;



    // Use this for initialization
    void Start()
    {
        renderer = GetComponentInChildren<MeshRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = normalizeVel(initDir());
        effectContainer = transform.Find("EffectContainer").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // check if player has just activated/deactivated waveform
        if (Waveform.active && !waveForm)
        { enterWaveform(); }
        else if (!Waveform.active && waveForm)
        { exitWaveform(); }

        rigidBody.velocity = normalizeVel(rigidBody.velocity);
    }




    // triggered when player activates waveform
    private void enterWaveform()
    {
        // rotate velocity according to spin
        switch (spin)
        {
            case ParticleSpin.UP:
                rigidBody.velocity = Quaternion.Euler(0, 0, -90) * normalizeVel(rigidBody.velocity);
                break;
            case ParticleSpin.DOWN:
                rigidBody.velocity = Quaternion.Euler(0, 0, 90) * normalizeVel(rigidBody.velocity);
                break;
        }


        // hide unless visibleInWaveform is enabled
        if (!visibleInWaveForm)
        {
            renderer.enabled = false;
            effectContainer.SetActive(false);
        }


        waveForm = true;
    }

    // triggered when player deactivates waveform
    private void exitWaveform()
    {
        // reverse velocity rotation according to spin
        switch (spin)
        {
            case ParticleSpin.UP:
                rigidBody.velocity = Quaternion.Euler(0, 0, 90) * normalizeVel(rigidBody.velocity);
                break;
            case ParticleSpin.DOWN:
                rigidBody.velocity = Quaternion.Euler(0, 0, -90) * normalizeVel(rigidBody.velocity);
                break;
        }


        // unhide
        renderer.enabled = true;
        effectContainer.SetActive(true);


        waveForm = false;
    }

    // takes a velocity vector and returns the closest velocity vector that is allowed for this particle
    private Vector2 normalizeVel(Vector2 vel)
    {
        switch (type)
        {
            case ParticleType.A:
                if (waveForm)
                {
                    if (vel.x < 0)
                    {
                        return new Vector2(-speed, 0.0f);
                    }
                    else
                    {
                        return new Vector2(speed, 0.0f);
                    }
                }
                else
                {
                    if (vel.y < 0)
                    {
                        return new Vector2(0.0f, -speed);
                    }
                    else
                    {
                        return new Vector2(0.0f, speed);
                    }
                }
            case ParticleType.B:
                if (waveForm)
                {
                    if (vel.y < 0)
                    {
                        return new Vector2(0.0f, -speed);
                    }
                    else
                    {
                        return new Vector2(0.0f, speed);
                    }

                }
                else
                {
                    if (vel.x < 0)
                    {
                        return new Vector2(-speed, 0.0f);
                    }
                    else
                    {
                        return new Vector2(speed, 0.0f);
                    }
                }
            case ParticleType.C:

                float x = speed;
                float y = speed;

                if (vel.x < 0)
                { x = -speed; }
                if (vel.y < 0)
                { y = -speed; }

                return new Vector2(x, y);
        }

        return new Vector2(0, 0);
    }

    // generates an initial direction vector for the particle based on the startDirection setting 
    Vector2 initDir()
    {
        switch (startDirection)
        {
            case ParticleDirection.N:
                return new Vector2(0, 1);
            case ParticleDirection.S:
                return new Vector2(0, -1);
            case ParticleDirection.W:
                return new Vector2(-1, 0);
            case ParticleDirection.E:
                return new Vector2(1, 0);
            case ParticleDirection.NW:
                return new Vector2(-1, 1);
            case ParticleDirection.NE:
                return new Vector2(1, 1);
            case ParticleDirection.SW:
                return new Vector2(-1, -1);
            case ParticleDirection.SE:
                return new Vector2(1, -1);

        }

        return new Vector2(0, 0);
    }



}

