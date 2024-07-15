using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class SignUpButton : MonoBehaviour
{
    public TMP_InputField user;
    public TMP_InputField passwd;
    public TextMeshProUGUI status;

    public void DangKyButton()
    {
        StartCoroutine(SignUp());
    }

    IEnumerator SignUp()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", user.text);
        form.AddField("passwd", passwd.text);

        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/dangky.php", form);

        yield return www.SendWebRequest(); //đợi đến khi nào sever hồi đáp mới chạy tiếp
        //yield return new WaitForSeconds(60); //đợi 60s rồi chạy các đoạn code dưới

        if (!www.isDone)
        {
            status.text = "Kết nối không thành công";
        }
        else
        {
            string get = www.downloadHandler.text;

            switch (get)
            {
                case "exist":
                    status.text = "Tài khoản đã tồn tại";
                    break;
                case "OK":
                    status.text = "Đăng ký thành công";
                    break;
                case "ERROR":
                    status.text = "Đăng ký không thành công";
                    break;
            }
        }
    }
}
