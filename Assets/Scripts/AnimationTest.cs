using UnityEngine;
using System.Collections;

public class AnimationTest : MonoBehaviour {

	public Animation anim;
	public AnimationClip RunCycle; 
	public GameObject Character; 

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation>();
		RunCycle = anim.GetClip ("RunCycle");
	
	}
	
	// Update is called once per frame
	void Update () {
		if (RunCycle != null)
			Debug.Log ("RunCycle loaded"); 
	}
}
