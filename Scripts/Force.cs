using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 一个简单的作用力实现
public class Force : MonoBehaviour
{
    // 作用时间
    public float remainTime = 5;

    // 作用力
    public Vector3 force = new Vector3(1, 0, 0);

    // 小球
    private Ball ball;
    
    

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Ball>();

        // 设置小球当前的作用力
        ball.AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        // 物理引擎的频率更新建议用FixedUpdate
    }

    // 固定帧数率的频率调用此函数
    // 物理引擎的频率更新建议用FixedUpdate
    void FixedUpdate()
    {
        // 给小球一个1牛顿的力，沿着全局坐标的X轴方向
        if (remainTime <= 0)
        {
            return;
        }

        Debug.Log("remainTime = " + remainTime);

        remainTime -= Time.fixedDeltaTime;
        

        // 可通过积分算式应用于各对象上的作用力效果
        ball.Intergate(Time.deltaTime);

        if (remainTime <= 0)
        {
            // 清空作用力
            ball.ClearForce();
        }

    }
}
