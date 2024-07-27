using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public static game_manager instance;
    public character[] characters;

    public character current_character;

    private void Awake()
    {
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

    private void Start()
    {
        if (characters.Length > 0)
        {
            current_character = characters[0];
        }
    }

    public void SetCharacter(character character)
    {
        current_character = character;
    }


}
