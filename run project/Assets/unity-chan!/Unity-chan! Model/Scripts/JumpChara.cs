using UnityEngine;
using System.Collections;
 
public class JumpChara : MonoBehaviour {
 
	private Animator animator;
	private CharacterController characterController;
	//�@���x
	private Vector3 velocity;
	//�@�W�����v��
	[SerializeField]
	private float jumpPower = 5f;
 
	void Start () {
		animator = GetComponent<Animator>();
		characterController = GetComponent<CharacterController>();
		velocity = Vector3.zero;
	}
 
	void Update () {
		if (characterController.isGrounded) {
			velocity = Vector3.zero;
			var input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
 
			//�@�����L�[������������Ă���
			if(input.magnitude > 0f) {
				animator.SetFloat("Speed", input.magnitude);
				transform.LookAt(transform.position + input);
				velocity += input.normalized * 2;
			//�@�L�[�̉���������������ꍇ�͈ړ����Ȃ�
			} else {
				animator.SetFloat("Speed", 0f);
			}
			//�@�W�����v�L�[�i�f�t�H���g�ł�Space�j����������Y�������̑��x�ɃW�����v�͂𑫂�
			if(Input.GetButtonDown("Jump")) {
				velocity.y += jumpPower;
			}
		}
 
		velocity.y += Physics.gravity.y * Time.deltaTime;
		characterController.Move(velocity * Time.deltaTime);
	}
}