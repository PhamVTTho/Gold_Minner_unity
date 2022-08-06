using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target_Level_Design : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI targetScoreText;
    [SerializeField] private int levelDesgin;
    [SerializeField] private int targetScore;
    [SerializeField] private int[] levelTargetScore;

    void Start()
    {

        levelTargetScore = new int[levelDesgin];
        for(int i = 1; i < levelDesgin; i++)
        {
            if(PlayerPrefs.GetFloat("Game_Level") == i)
            {
                levelTargetScore[i - 1] = targetScore * i;
                targetScoreText.text = levelTargetScore[i - 1].ToString();
            }
        }
    }
}
