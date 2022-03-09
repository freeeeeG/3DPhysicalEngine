﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // 质量
    public int mass = 1;

    // 位置
    public Vector3 location;

    // 速度
    public Vector3 velocity = Vector3.zero;

    // 加速度
    public Vector3 acceleration = Vector3.zero;

    // 阻尼，比如空气阻力，同学们可以思考一下，不用实现
    public float damping = 0.9f;

    //作用力，注意这是合力
    public Vector3 forceAccum = Vector3.zero; 


    // Start is called before the first frame update
    void Start()
    {
        location = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 在物理引擎中，通常计算施加于各对象上的作用力，
    // 并通过牛顿第二定律计算加速度,
    // 随后，可通过积分算式应用于各对象上,
    public void Intergate(float duration)
    {
        // 作用时间必须大于0
        if(duration <= 0)
        {
            return;
        }

        // 更新位置
        location += velocity * duration;
        UpdateBallPos();

        // 计算加速度
        if (mass <= 0)
        {
            return;
        }

        if(forceAccum != Vector3.zero)
        {
            acceleration = forceAccum / mass;
        }

        // 更新速度
        velocity += acceleration * duration;

        // 计算阻尼（比如空气阻力等）
        // 这里同学们思考一下如何实现就行，不需要代码实现

    }

    // 更新球在游戏世界的位置
    private void UpdateBallPos() 
    {
        transform.position = location;
    }

    // 添加作用的合力到球上
    public void AddForce(Vector3 force)
    {
        forceAccum += force;
    }

    // 清除作用力
    public void ClearForce()
    {
        forceAccum = Vector3.zero;
        acceleration = Vector3.zero;
    }
}
