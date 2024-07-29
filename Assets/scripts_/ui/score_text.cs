using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class score_text : MonoBehaviour
{
    public static score_text instance;
    [SerializeField] TextMeshProUGUI score_text_;
    int score_ = 0;
    // Start is called before the first frame update
    void Start()
    {
        void Awake()
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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void set_text(int count_)
    {
        score_ += count_;
        score_text_.text = $"score : {score_}";
    }
}
