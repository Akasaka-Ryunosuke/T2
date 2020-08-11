using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

/// <summary>
/// 脚本生命周期/必然事件/消息 Message
/// </summary>

public class LifeCycle : MonoBehaviour
{
    //脚本： .cs的文本文件  类文件
    //      附加到游戏物体中，定义游戏对象行为指令的代码。

    //C#类：
    //字段
    //属性
    //构造函数
    //方法

    //脚本：
    //字段
    //方法


    //序列化字段  作用：允许在编辑器中显示私有变量
    [SerializeField]
    private int a = 100;

    //作用：在编辑器中隐藏字段
    [HideInInspector]
    public float b;

    //作用：在编辑器中设置变量范围
    [Range(0, 100)]
    public int c = 0;



    //属性在编辑器中不能显示，通常脚本中不写
    public int A
    {
        get
        { return this.a; }
        set
        {
            this.a = value;
        }
    }

    //许多多线程引发bug，脚本中不写，因为会执行两次（由Log看出）
    public LifeCycle()
    {
        Debug.Log("构造函数");
        //不能在子线程中访问主线程成员
        //（尽量不要在脚本中写构造函数，写也不要用Unity包里的东西，易bug）
        //b = Time.time;
    }



    //********************初始阶段********************
    //执行时机： 创建游戏对象-->立即执行一次（永远早于任何物体的Start）
    private void Awake()
    {
        //用于初始化，判断是否执行此脚本 this.enable = true
        Debug.Log("Awake--" + Time.time);
    }

    //执行时机： 脚本启用-->执行一次
    private void OnEnable()
    {
        Debug.Log("Awake--" + Time.time);
    }

    //执行时机： 创建游戏对象-->且脚本启用-->才执行一次
    private void Start()
    {
        Debug.Log("Awake--" + Time.time);
    }

    //********************物理阶段********************
    //执行时机：每隔固定时间执行一次（默认0.02s）可以修改
    //适用性：适合对物体进行物理操作（移动、旋转...），不会受到渲染影响
    private void FixedUpdate()
    {
        //不用担心渲染时间不固定
        Debug.Log(Time.time);

    }


    //********************游戏逻辑********************
    //执行时机：渲染帧执行，执行间隔不固定
    //适用性：处理游戏逻辑
    private void Update()
    {
        
    }

    //执行时机：每次Update执行后
    //适用性：跟随逻辑
    private void LateUpdate()
    {

    }
}
