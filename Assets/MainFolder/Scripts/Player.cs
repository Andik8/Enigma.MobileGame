using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;
		public Joystick joystick;

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;

		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update (){
		//	if (Input.GetKey(KeyCode.Space)) { 
		//	anim.SetBool("Flip", true);
		//	} else
		//	{
		//	anim.SetBool("Flip", false);
		//	}
			//if (Input.GetKey ("w")) {
			//	anim.SetInteger ("AnimationPar", 1);
			//}  else {
			//	anim.SetInteger ("AnimationPar", 0);
			//}

			if(controller.isGrounded){
				moveDirection = new Vector3(-joystick.Horizontal, 0, -joystick.Vertical);
				anim.SetInteger("AnimationPar", 0);
			if (moveDirection.sqrMagnitude > 0)
				{
				anim.SetInteger("AnimationPar", 1);
				transform.rotation = Quaternion.LookRotation(moveDirection, transform.up);
				//moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
				//moveDirection = transform.forward * joystick.Horizontal * speed;
				}
				
			}


		//float turn = Input.GetAxis("Horizontal");
		//	//float turn = joystick.Horizontal;
		//transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= gravity * Time.deltaTime;
		}
}
