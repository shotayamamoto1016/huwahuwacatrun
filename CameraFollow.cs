using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //�J�������v���C���[��Ǐ]����d�g�݂�����
    public Transform target;

    //�J�������ǂ̈ʒu�Ŕz�u���邩���߂�I�t�Z�b�g
    //�J�������v���C���̑O�ɔz�u����Ȃ��悤��z���𕉂̒l�ɐݒ�
    public Vector3 offset = new Vector3(0, 2, -10);
   
    //LateUpdate()��Update()�̌�ɖ��t���[���Ă΂��
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPos = target.position + offset;
            //�J�������㉺�������Ȃ��悤�ɐ��䂷��
            //Clamp(value, min, max) �́A�w��͈͂ɐ�������֐�
            newPos.y = Mathf.Clamp(newPos.y, 0f, 10f);
            //�J�����̈ʒu���X�V����
            transform.position = newPos;
        }
    }
}
