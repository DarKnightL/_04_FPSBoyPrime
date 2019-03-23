using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager gm;

    public GameObject robotPlayer;

    private PlayerHealth playerHealth;
    [SerializeField]
    private int targetScore = 10;
    private int currentScore;


    public enum GameState { Playing, GameOver, Winning };
    public GameState gameState;


    public Text scoreText;
    public Text healthText;


    private void Start()
    {
        gm = GetComponent<GameManager>();
        playerHealth = robotPlayer.GetComponent<PlayerHealth>();
        if (robotPlayer == null)
        {
            robotPlayer = GameObject.FindGameObjectWithTag("Player");
        }
        currentScore = 0;
    }


    private void Update()
    {
        switch (gameState)
        {
            case GameState.Playing:
                scoreText.text = "Score: " + currentScore;
                healthText.text = "Health: " + playerHealth.health;
                if (playerHealth.isAlive == false)
                {
                    gm.gameState = GameState.GameOver;
                }
                else if (currentScore >= targetScore)
                {
                    gm.gameState = GameState.Winning;
                }
                break;


            case GameState.Winning:
                SceneManager.LoadScene(0);
                break;


            case GameState.GameOver:
                SceneManager.LoadScene(0);
                break;

        }
    }


    public void AddScore(int score){

        currentScore += score;

    }


    public void PlayerTakeDamage(int damage){
        if (playerHealth!=null)
        {
            playerHealth.TakeDamage(damage);
        }

    }
}
