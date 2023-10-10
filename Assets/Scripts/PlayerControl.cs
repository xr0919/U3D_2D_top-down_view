using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //动画组件
    private Animator ani;
    //刚体组件
    private Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start()
    {
        //获取两个组件
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //按下左或右
        if(horizontal != 0)
        {
            ani.SetFloat("Horizontal", horizontal);
            //游戏不支持8方向。向一个轴移动另一个轴不变
            ani.SetFloat("Vertical", 0);


        }
        //按下上或下
        if (vertical != 0)
        {
            ani.SetFloat("Horizontal", 0);
            ani.SetFloat("Vertical", vertical);

        }
        //切换跑步状态
        Vector2 dir = new Vector2(horizontal, vertical);
        ani.SetFloat("Speed", dir.magnitude);//向量的长度
        //移动向该方向
        rBody.velocity = dir * 0.3f;


    }
}
