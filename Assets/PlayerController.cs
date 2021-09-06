using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {

	Rigidbody rb;
	Animator anim;
	[SerializeField]
	float speed;
	[SerializeField]
	float jumpforce;
	[SerializeField]
	Text scoreUI;
	float lenghtinZ = 7.6f;
	float score = 0;
	Vector3 lastposition;
	float	_score = 0f;
	
	[SerializeField]
	GameObject platform;
	[SerializeField]
	Transform firstobject;
	[SerializeField]
	

	void Awake(){
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
		rb.velocity = Vector3.forward * speed;
		lastposition = firstobject.transform.position;

		InvokeRepeating("Spawning", 0f, 0.3f);

		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) ){
			anim.SetTrigger("Jump");
			rb.AddForce(Vector3.up * jumpforce , ForceMode.Impulse);
			
		}
		ScoreUpdate();
		
	}
	private void ScoreUpdate(){
	  
	  _score += (5f * Time.deltaTime);
	  score = Mathf.RoundToInt(_score);


		scoreUI.text = score.ToString();
	}	
	void Spawning(){
		GameObject _object = Instantiate(platform) as GameObject;
		_object.transform.position = lastposition + new Vector3(0f,0f,lenghtinZ);
		lastposition = _object.transform.position;

	}
	void  OnCollisionEnter(Collision collisionInfo)
	{
		if(collisionInfo.gameObject.tag == "Water")
			GameOver();
		
		
	}
    private	void GameOver(){
		Debug.Log("game over");
	}
}
