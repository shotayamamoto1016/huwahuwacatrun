using UnityEngine;
using TMPro;

public class ResultUIController : MonoBehaviour
{
    //�R�C���l�������\��UI
    public TextMeshProUGUI coinResultText;

    
    void Start()
    {
        //�Q�b�g�ł����R�C��������\������
        int finalCoinCount = PlayerController.coinCount;

        coinResultText.text = "coin:" + finalCoinCount;
    }

   
}
