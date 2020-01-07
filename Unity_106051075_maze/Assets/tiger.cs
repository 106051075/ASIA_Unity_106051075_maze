using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiger : MonoBehaviour
{
    #region 欄位區域
    // Start is called before the first frame update
    [Header("G8雞基本資料"), Tooltip("Call me G8"), Range(1, 1000)]
    public int speed = 10;
    public float turn = 20.5f;
    public string _Name = "老虎";
    public Transform tran;
    public Rigidbody rig;
    public Animator ani;
    #endregion
    [Header("撿物品位置")]

    public Rigidbody rigCatch;

    private void Update()
    {
        Turn();
        Run();
        Hit();
    }
    #region 方法區域

    private void OnTriggerStay(Collider other)
    {
        print(other.name);
        if (other.name == "Tacos" && ani.GetCurrentAnimatorStateInfo(0).IsName("攻擊"))
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
            other.GetComponent<HingeJoint>().connectedBody = rigCatch;

        }
        if (other.name == "岩石堆" && ani.GetCurrentAnimatorStateInfo(0).IsName("攻擊"))
        {
            GameObject.Find("Tacos").GetComponent<HingeJoint>().connectedBody = null;
        }
    }
    /// <summary>
    /// 跑步
    /// </summary>
    private void Run()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("攻擊")) return;

        float v = Input.GetAxis("Vertical");
        rig.AddForce(tran.forward * speed * v * Time.deltaTime);
        ani.SetBool("走路開關", v != 0);
    }
    /// <summary>
    /// 旋轉
    /// </summary>
    private void Turn()
    {
        float h = Input.GetAxis("Horizontal");
        tran.Rotate(0, turn * h, 0);
    }

    /// <summary>
    /// 抓取
    /// </summary>
    private void Hit()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ani.SetTrigger("攻擊開關");
        }
    }
    /// <summary>
    /// 任務
    /// </summary>
    private void Task()
    {

    }
    #endregion 



}
