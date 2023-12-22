using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //�@�J�E���g�_�E�������ǂ���
    public bool IsCountDown { get; set; }
    //�@�J�E���g�_�E��������\������e�L�X�g
    private TextMeshProUGUI countDownText;
 
    public bool GameOver{get; set;}
    // Start is called before the first frame update
    void Start()
    {
        countDownText = GameObject.Find("CountDownText").GetComponent<TextMeshProUGUI>();
	    //�@�Q�[���֘A������
	    IsCountDown = true;
	    StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
                Quit();
        }
    }

    public void ClearGame(){
        GameOver = true;
    }
    public void EndGame(){
        GameOver = true;
    }
    //�@�J�E���g�_�E���\��
    IEnumerator CountDown() {
	    //�@�X�e�[�W���̕\��
	    countDownText.text = SceneManager.GetActiveScene().name;
	    //�@��������1�b�o�ߖ��ɐ������X�V
	    yield return new WaitForSeconds(1f);
	    countDownText.text = "3";
	    yield return new WaitForSeconds(1f);
	    countDownText.text = "2";
	    yield return new WaitForSeconds(1f);
	    countDownText.text = "1";
	    yield return new WaitForSeconds(1f);
	    countDownText.text = "Start";
	    IsCountDown = false;
	    yield return new WaitForSeconds(0.5f);
	    countDownText.gameObject.SetActive(false);
    }
    public void Quit(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
