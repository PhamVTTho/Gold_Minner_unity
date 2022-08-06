using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class GamePlayScript : MonoBehaviour {
	public TextMeshProUGUI timeText;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI targetText;
	public TextMeshProUGUI levelText;
	public int score;
	public float time;
	public int seconds;
	public int targetLevelScore;
	public bool timeRunning;

	public GameObject menuEndGame;
	public GameObject menuNextLevel;
	[SerializeField] int[] levelTarget;

	public int levelDesign;

	void Start () {
		levelText.text = "Level " + PlayerPrefs.GetFloat("Game_Level"); 
		levelTarget = new int[levelDesign];
		timeRunning = true;
		for(int i = 1;i <= levelDesign; i++)
        {
			levelTarget[i - 1] = targetLevelScore * i;
        }
		for(int i = 1; i <= levelTarget.Length; i++)
        {
			if (PlayerPrefs.GetFloat("Game_Level") == i)
			{
				targetText.text = levelTarget[i - 1].ToString();
			}
		}
	}

	void Update () {
        if (timeRunning == true)
        {
			if(time > 0)
            {
                time -= Time.deltaTime;
				seconds = (int)(time % 60);

			}else if(time <= 0)
            {
				time = 0;
				timeRunning = false;
				for(int i = 1; i <= levelTarget.Length; i++)
                {
					if (PlayerPrefs.GetFloat("Game_Level") == i)
					{
						if(score >= levelTarget[i - 1])
                        {
							nextLevel();
                        }
                        else if(score < levelTarget[i - 1])
                        {
							endGame();
                        }
					}
				}
            }
        }
		timeText.text = seconds.ToString();
		PlayerPrefs.SetInt("Score", score);
		scoreText.text = PlayerPrefs.GetInt("Score").ToString();
	}
	public void endGame() {
		menuEndGame.SetActive(true);
	}
	public void nextLevel()
    {
		menuNextLevel.SetActive(true);
    }
}
