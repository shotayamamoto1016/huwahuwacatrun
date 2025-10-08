using Unity.VisualScripting;
using UnityEngine;
//LoadSceneを使うために必要
using UnityEngine.SceneManagement;
//UIを使うために必要
using UnityEngine.UI;
//スクリプトからTextMeshProに触れるために必要
using TMPro;


public class PlayerController : MonoBehaviour
{
    //ゲームオブジェクトに物理挙動を付与するコンポーネント
    Rigidbody2D rigid2D;

    //ゲームオブジェクトの移動速度を設定する
    float jumpForce = 600.0f;

    //歩く時の力を30に設定
    float walkForce = 30.0f;

    //歩く時の最大速度を設定
    float maxWalkSpeed = 2.0f;

    //歩く時のスプライトを設定
    public Sprite[] walkSprites;

    //ジャンプするときのスプライトを設定
    public Sprite jumpSprite;

    float time = 0;

    int idx = 0;

    //spriteRendererの宣言
    SpriteRenderer spriteRenderer;

    //コイン枚数表示用UI
    public  TextMeshProUGUI CoinText;

    //獲得したコイン数
    //staticはシーンが切り替わっても記憶する
    public static int coinCount = 0;

    public Button ReturnButton;

    //static関数を使って記憶
    //public static int totalCoincount = 0;

   

   

    
    void Start()
    {
        //フレームレートを60に設定
        Application.targetFrameRate = 60;

        //Rigidbody2Dコンポーネントを取得
        this.rigid2D = GetComponent<Rigidbody2D>();

        //SpriteRendererコンポーネントを取得
        this.spriteRenderer = GetComponent<SpriteRenderer>();

        //coin初期化
        coinCount = 0;
        //totalCoincount = 0;
        //初期化時に表示を更新
        CoinText.text = "coin: " + coinCount;
       
    }

    
    void Update()
    {
        //ジャンプする
        if (Input.GetMouseButtonDown(0) && this.rigid2D.linearVelocityY == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //右に移動する
        if (this.rigid2D.linearVelocityX < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * walkForce);
        }

        //アニメーション
        //プレイヤのY方向の速度(linearVelocityY)を調べ０でなければジャンプのスプライトを表示する
        if (this.rigid2D.linearVelocityY != 0)
        {
            this.spriteRenderer.sprite = this.jumpSprite;
        }
        else
        {
            this.time += Time.deltaTime;

            if (this.time > 0.1f)
            {
                //0.1秒貯まったら中身を空にする
                this.time = 0;
                //SpriteRendererコンポーネントのsprite変数に切り替えたいスプライトを代入
                this.spriteRenderer.sprite = this.walkSprites[this.idx];
                //idxが０の場合は1に、idxが１の場合は０にする
                this.idx = 1 - this.idx;
            }
        }

        //画面外に出た場合は最初から
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    //ゴールに到着
    void OnTriggerEnter2D(Collider2D other)
    {
        //flag_0に触れたとき
        if (other.CompareTag("Coin"))
        {
            Debug.Log("コイン獲得");
            //コインに触れたらcoinCountを増やす
            coinCount++;
            //コインの数をUIに反映する
            //totalCoincount = coinCount;
            //コインの数を初期化する
            CoinText.text = "coin: " + coinCount;
            //コインオブジェクトを非表示にする
            Destroy(other.gameObject);
        }
        //flag_0に触れたとき
        if (other.CompareTag("Goal"))
        {
            Debug.Log("ゴール");
            //ClearSceneへ移動する
            SceneManager.LoadScene("clearScene");
        }
    }
    //タイトルシーンへ
    public void ReturnGame()
    {
        SceneManager.LoadScene("TitleScene");
    }
   
}
