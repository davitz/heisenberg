using UnityEngine;
using System.Collections;

public class Dissapearing_Key : MonoBehaviour {

    private MeshRenderer myRenderer;
    private Collider2D myCollider;
    private GameObject MyGO;

    private void Start()
    {
        myRenderer = GetComponent <MeshRenderer>();
        myCollider = GetComponent<Collider2D>();
        MyGO = gameObject;
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            MyGO.SetActive(false);
            //myRenderer.enabled = false; //Disable this GameObject's renderer
            myCollider.enabled = false; //Disable this GameObject's collider
        }
    }
}
