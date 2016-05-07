using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ParticleType { A, B, C }

public enum ParticleSpin { UP, DOWN }

public enum ParticleDirection { N, S, W, E, NW, NE, SW, SE }

public class ParticleBehavior : MonoBehaviour
{

    public ParticleType type = ParticleType.A;

    public ParticleSpin spin = ParticleSpin.UP;

    public ParticleDirection startDirection = ParticleDirection.N;

    private bool waveForm = false;

    public float speed = 20.0f;

    private Rigidbody2D rigidBody;

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

    Vector2 initialVel()
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


    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = normalizeVel(initialVel());
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = normalizeVel(rigidBody.velocity);
    }
}
