using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    float score_ = 0, Highscore = 0;
    public static game_manager instance;
    public character[] characters;
    public character current_character;

    void Awake()
    {
        Highscore = PlayerPrefs.GetFloat("highscore");
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

        UIManager.Instance.setText($"score : {score_}");
    }

    public void SetCharacter(character character)
    {
        current_character = character;
    }

    public void set_text(float count_)
    {
        score_ += count_;
        if (score_ > Highscore)
        {
            Highscore = score_;
            PlayerPrefs.SetFloat("highscore", Highscore);
            Debug.Log($"da luu : {Highscore} ");
        }
        UIManager.Instance.setText($"score : {score_}");
    }
}
