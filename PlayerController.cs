using Unity.VisualScripting;
using UnityEngine;
//LoadScene���g�����߂ɕK�v
using UnityEngine.SceneManagement;
//UI���g�����߂ɕK�v
using UnityEngine.UI;
//�X�N���v�g����TextMeshPro�ɐG��邽�߂ɕK�v
using TMPro;


public class PlayerController : MonoBehaviour
{
    //�Q�[���I�u�W�F�N�g�ɕ���������t�^����R���|�[�l���g
    Rigidbody2D rigid2D;

    //�Q�[���I�u�W�F�N�g�̈ړ����x��ݒ肷��
    float jumpForce = 600.0f;

    //�������̗͂�30�ɐݒ�
    float walkForce = 30.0f;

    //�������̍ő呬�x��ݒ�
    float maxWalkSpeed = 2.0f;

    //�������̃X�v���C�g��ݒ�
    public Sprite[] walkSprites;

    //�W�����v����Ƃ��̃X�v���C�g��ݒ�
    public Sprite jumpSprite;

    float time = 0;

    int idx = 0;

    //spriteRenderer�̐錾
    SpriteRenderer spriteRenderer;

    //�R�C�������\���pUI
    public  TextMeshProUGUI CoinText;

    //�l�������R�C����
    //static�̓V�[�����؂�ւ���Ă��L������
    public static int coinCount = 0;

    public Button ReturnButton;

    //static�֐����g���ċL��
    //public static int totalCoincount = 0;

   

   

    
    void Start()
    {
        //�t���[�����[�g��60�ɐݒ�
        Application.targetFrameRate = 60;

        //Rigidbody2D�R���|�[�l���g���擾
        this.rigid2D = GetComponent<Rigidbody2D>();

        //SpriteRenderer�R���|�[�l���g���擾
        this.spriteRenderer = GetComponent<SpriteRenderer>();

        //coin������
        coinCount = 0;
        //totalCoincount = 0;
        //���������ɕ\�����X�V
        CoinText.text = "coin: " + coinCount;
       
    }

    
    void Update()
    {
        //�W�����v����
        if (Input.GetMouseButtonDown(0) && this.rigid2D.linearVelocityY == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //�E�Ɉړ�����
        if (this.rigid2D.linearVelocityX < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * walkForce);
        }

        //�A�j���[�V����
        //�v���C����Y�����̑��x(linearVelocityY)�𒲂ׂO�łȂ���΃W�����v�̃X�v���C�g��\������
        if (this.rigid2D.linearVelocityY != 0)
        {
            this.spriteRenderer.sprite = this.jumpSprite;
        }
        else
        {
            this.time += Time.deltaTime;

            if (this.time > 0.1f)
            {
                //0.1�b���܂����璆�g����ɂ���
                this.time = 0;
                //SpriteRenderer�R���|�[�l���g��sprite�ϐ��ɐ؂�ւ������X�v���C�g����
                this.spriteRenderer.sprite = this.walkSprites[this.idx];
                //idx���O�̏ꍇ��1�ɁAidx���P�̏ꍇ�͂O�ɂ���
                this.idx = 1 - this.idx;
            }
        }

        //��ʊO�ɏo���ꍇ�͍ŏ�����
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    //�S�[���ɓ���
    void OnTriggerEnter2D(Collider2D other)
    {
        //flag_0�ɐG�ꂽ�Ƃ�
        if (other.CompareTag("Coin"))
        {
            Debug.Log("�R�C���l��");
            //�R�C���ɐG�ꂽ��coinCount�𑝂₷
            coinCount++;
            //�R�C���̐���UI�ɔ��f����
            //totalCoincount = coinCount;
            //�R�C���̐�������������
            CoinText.text = "coin: " + coinCount;
            //�R�C���I�u�W�F�N�g���\���ɂ���
            Destroy(other.gameObject);
        }
        //flag_0�ɐG�ꂽ�Ƃ�
        if (other.CompareTag("Goal"))
        {
            Debug.Log("�S�[��");
            //ClearScene�ֈړ�����
            SceneManager.LoadScene("clearScene");
        }
    }
    //�^�C�g���V�[����
    public void ReturnGame()
    {
        SceneManager.LoadScene("TitleScene");
    }
   
}
