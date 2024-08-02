using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class GetHighScore : MonoBehaviour
{
    
    public TMP_InputField token;
    public TextMeshProUGUI thongbao;


    public void GetScorebotton()
    {
        StartCoroutine(GetScore());
    }
    IEnumerator GetScore()
    {
        WWWForm form = new WWWForm();

        form.AddField("token", token.text);
        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/GetHighscore.php",form);
        yield return www.SendWebRequest();


        if (!www.isDone)
        {
            thongbao.text = "Bạn cần đăng nhập để thực hiện thao tác này: tiến hành đăng nhập lại.";
            Debug.Log("Kết nối không thành công: " + www.error);
        }
        else
        {
            string get = www.downloadHandler.text;
            if (get.Contains("Lỗi"))
            {
                thongbao.text = "Không kết nối được tới server";
            }
            else
            {
                thongbao.text = get;
            }

        }


    }

    
}
