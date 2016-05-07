using UnityEngine;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Respawn : MonoBehaviour {
    bool respawn;
    Transform SpawnPoint;

    // Use this for initialization
    void Start() {
        respawn = false;        
    }

    // Update is called once per frame
    void Update() {

        if (respawn) { transform.position = SpawnPoint.position; }
    }

    void OnTriggerEnter(Collider2D other)
    {
        if (other.tag == "Player") { respawn = true; }
    }
}
