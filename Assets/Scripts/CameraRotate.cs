using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    private GameObject player;       //�v���C���[�i�[�p

    // Use this for initialization
    void Start()
    {
        //unitychan��player�Ɋi�[
        player = GameObject.Find("Golem_Idle");
    }

    // Update is called once per frame
    void Update()
    {
        //���V�t�g��������Ă��鎞
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //���j�e�B�����𒆐S��-5f�x��]
            transform.RotateAround(player.transform.position, Vector3.up, -5f);
        }
        //�E�V�t�g��������Ă��鎞
        else if (Input.GetKey(KeyCode.RightShift))
        {
            //���j�e�B�����𒆐S��5f�x��]
            transform.RotateAround(player.transform.position, Vector3.up, 5f);
        }
    }
}