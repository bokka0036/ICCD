using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //　カウントダウン中かどうか
    public bool IsCountDown { get; set; }
    //　カウントダウン数字を表示するテキスト
    private TextMeshProUGUI countDownText;
 
    public bool GameOver{get; set;}
    // Start is called before the first frame update
    void Start()
    {
        countDownText = GameObject.Find("CountDownText").GetComponent<TextMeshProUGUI>();
	    //　ゲーム関連初期化
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
    //　カウントダウン表示
    IEnumerator CountDown() {
	    //　ステージ名の表示
	    countDownText.text = SceneManager.GetActiveScene().name;
	    //　ここから1秒経過毎に数字を更新
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
