using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    [SerializeField] public int GameLevel;
    void Start()
    {
        PlayerPrefs.SetFloat("Game_Level", GameLevel);
    }

}
