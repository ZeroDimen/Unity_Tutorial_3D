using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FPS_GameManager : MonoBehaviour
{
    public static FPS_GameManager instance;

    public GameObject gameLabel;
    private FPS_PlayerMove player;
    private Text gameText;
    // 싱글톤 변수
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public enum GameState
    {
        Ready,
        Run,
        GameOver
    }
    
    public GameState gState;

    private void Start()
    {
        gState = GameState.Ready;
        player = GameObject.Find("Player").GetComponent<FPS_PlayerMove>();
        
        gameText = gameLabel.GetComponent<Text>();
        gameText.text = "Ready...";
        gameText.color = new Color32(255 , 195 , 0 ,255);
        StartCoroutine(ReadyToStart());
    }

    private void Update()
    {
        if (player.hp <= 0)
        {
            player.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f);
            
            gameLabel.SetActive(true);
            gameText.text = "Game Over";
            
            gameText.color = new Color32(255 , 0 , 0 ,255);
            gState = GameState.GameOver;
        }
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);
        gameText.text = "Go!";
        
        yield return new WaitForSeconds(0.5f);
        gameLabel.SetActive(false);
        gState = GameState.Run;
    }
}
