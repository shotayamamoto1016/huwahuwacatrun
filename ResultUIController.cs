using UnityEngine;
using TMPro;

public class ResultUIController : MonoBehaviour
{
    //コイン獲得枚数表示UI
    public TextMeshProUGUI coinResultText;

    
    void Start()
    {
        //ゲットできたコイン枚数を表示する
        int finalCoinCount = PlayerController.coinCount;

        coinResultText.text = "coin:" + finalCoinCount;
    }

   
}
