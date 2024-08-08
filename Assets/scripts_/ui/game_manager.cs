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
    public sounds[] music, sfx;
    public character current_character;
    public AudioSource music_source, sfx_source;

    void Awake()
    {
        Highscore = PlayerPrefs.GetFloat("highscore");

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
        play_music("bg");

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
        }
        UIManager.Instance.setText($"score : {score_}");
    }

    public void play_music(string name)
    {
        sounds s = Array.Find(music, x => x.name == name);

        music_source.clip = s.clip;
        music_source.Play();
    }
    
    public void play_sfx(string name)
    {
        sounds s = Array.Find(sfx, x => x.name == name);

        sfx_source.PlayOneShot(s.clip);
    }
}
