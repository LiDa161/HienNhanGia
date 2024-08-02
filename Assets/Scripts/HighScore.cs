using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class HighScore : MonoBehaviour
{
    public TMP_InputField diem;
    public TMP_InputField token;
    public TMP_InputField playername;
    public TextMeshProUGUI thongbao;

    public void Hightscorebotton()
    {
        StartCoroutine(InsertScore());
    }

    IEnumerator InsertScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("playerName", playername.text);
        form.AddField("token", token.text);
        form.AddField("score", diem.text);
        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/InsertHighscore.php", form);
        yield return www.SendWebRequest();

        if (!www.isDone)
        {
            thongbao.text = "Bạn cần đăng nhập để thực hiện thao tác này: tiến hành đăng nhập lại.";
        }
        else
        {
            string get = www.downloadHandler.text;
            if (get == "Done")
            {
                thongbao.text = "Đã lưu dữ liệu lên server thành công";
            }
            else
            {
                thongbao.text = "Không kết nối được server";
            }
             
        }
    }
}
