using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    bool is_gameover;
    public int score, high_score;
    public GameObject game_over, score_object;
    public static game_manager instance;
    public character[] characters;
    public sounds[] music, sfx;
    public character current_character;
    public AudioSource music_source, sfx_source;

    void Awake()
    {
        high_score = PlayerPrefs.GetInt("highscore");

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
    }

    void Update()
    {
        if (is_gameover)
        {
            player_die();
        }
    }

    public void SetCharacter(character character)
    {
        current_character = character;
    }

    public void add_score(int score_value)
    {
        score += score_value;
        if (score > high_score)
        {
            high_score = score;
            PlayerPrefs.SetInt("highscore", high_score);
        }
    }

    public int get_score()
    {
        return score;
    }

    public int get_high_score()
    {
        return high_score;
    }

    public void kill_player()
    {
        is_gameover = true;
    }

    public void player_die()
    {
        game_over.SetActive(true);
    }

    public bool gameover_()
    {
        return is_gameover;
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
