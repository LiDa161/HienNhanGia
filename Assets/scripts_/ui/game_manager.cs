using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    int score_ = 0;
    int Highscore = 0;
    public static game_manager instance;
    public character[] characters;
    public character current_character;
    public TextMeshProUGUI textMeshProUGUI;

    void Awake()
    {
        Highscore = PlayerPrefs.GetInt("highscore");
        Debug.Log(Highscore);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (characters.Length > 0)
        {
            current_character = characters[0];
        }

        /*if (textMeshProUGUI != null)
        {*/
            textMeshProUGUI.text = $"score : {score_}";
        //}
    }

    public void SetCharacter(character character)
    {
        current_character = character;
    }

    public void set_text(int count_)
    {
        score_ += count_;
        if (score_ > Highscore)
        {
            Highscore = score_;
            PlayerPrefs.SetInt("highscore", Highscore);
            Debug.Log($"da luu : {Highscore} ");
        }
        textMeshProUGUI.text = $"score : {score_}";
    }
}
