using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //�������
    private Animator ani;
    //�������
    private Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start()
    {
        //��ȡ�������
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //���������
        if(horizontal != 0)
        {
            ani.SetFloat("Horizontal", horizontal);
            //��Ϸ��֧��8������һ�����ƶ���һ���᲻��
            ani.SetFloat("Vertical", 0);


        }
        //�����ϻ���
        if (vertical != 0)
        {
            ani.SetFloat("Horizontal", 0);
            ani.SetFloat("Vertical", vertical);

        }
        //�л��ܲ�״̬
        Vector2 dir = new Vector2(horizontal, vertical);
        ani.SetFloat("Speed", dir.magnitude);//�����ĳ���
        //�ƶ���÷���
        rBody.velocity = dir * 0.3f;


    }
}
