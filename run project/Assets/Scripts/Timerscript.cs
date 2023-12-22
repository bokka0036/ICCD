 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
 
public class TimerScript : MonoBehaviour {
	//�@�Q�[���}�l�[�W���[
	private GameManager gameManager;
	//�@�^�C�}�[��\������e�L�X�g
	private TextMeshProUGUI timerText;
	//�@�o�ߕb��
	private float seconds;
	//�@�X�g�b�v�E�H�b�`�p�t�B�[���h
	private Stopwatch stopWatch;
 
	// Start is called before the first frame update
	void Start() {
		//�@�R���|�[�l���g�̎擾
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		timerText = GetComponent<TextMeshProUGUI>();
		//�@�X�g�b�v�E�H�b�`�N���X���g���ꍇ
		stopWatch = new Stopwatch();
	}
 
	void Update() {
		//�@�Q�[���I�[�o�[���͈ȍ~�������Ȃ�
		if (gameManager.IsCountDown || gameManager.GameOver) {
			return;
		}
		//�@���Ԃ��v������
		TakeTime();
 
		////�@�X�g�b�v�E�H�b�`�N���X���g���ꍇ
		//stopWatch.Stop();
		//var timeSpan = stopWatch.Elapsed;
		//timerText.SetText("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
		//stopWatch.Start();
	}
	//�@���Ԍv�����\�b�h
	void TakeTime() {
		//�@1�b���₷
		seconds += Time.deltaTime;
		//�@TimeSpan�N���X���g���Ď��ԕb���擾����ׂ̏���
		var timeSpan = new TimeSpan(0, 0, (int)seconds);
		//�@���l���X�V
		timerText.SetText("{0:00}:{1:00}:{2:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
		//�@���܂�Ɏ��Ԃ�����������Q�[���I�[�o�[
		if (seconds >= 60 * 60 * 60) {
			gameManager.EndGame();
		}
	}
	//�@�o�ߎ��Ԃ�Ԃ�
	public int GetSeconds() {
		return (int)seconds;
	}
}