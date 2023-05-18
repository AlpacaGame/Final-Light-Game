using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spore_Boos : MonoBehaviour
{
    public float Hp = 100;
    public static float on_hp = 100;
    public static float 回血數字 = 5; //先以最高20
    public float 觀看王回血;

    public static bool 回血;

    void Start()
    {

    }

    // Update is called once per frame

    //Boos血量
    void Update()
    {
        on_hp = Hp;
        觀看王回血 = 回血數字;

        if (Hp <= 0)
        {
            Hp = 0;
            //SceneManager.LoadScene(1);
        }

        if (Hp >= 1800)
        {
            Hp = 1800.0f;
            //SceneManager.LoadScene(1);
        }

        
    }

    void FixedUpdate()
    {
        if (回血)
        {
            Hp += 回血數字 * Time.fixedDeltaTime;
        }

        else if(!回血)
        {
            Hp += 0;
        }
    }

        /*
        public float 時間釋放胞子 = 5.0f;
        public GameObject SporeAttack;

        public bool 時間控制隨機開關射擊 = false;
        public int 亂碼 = 0;
        public int 亂數最小值 = 1;
        public int 亂數最大值 = 8;
        //亂數生成這個數字就開砲
        public int 幸運數字開炮 = 7;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //手動施法
            if (Input.GetKey(KeyCode.M))
            {
                Vector3 胞子口pos = this.transform.position + new Vector3(0, 0, 0);
                Instantiate(SporeAttack, 胞子口pos, transform.rotation);
            }

            if (時間釋放胞子 > 0)
            {
                時間釋放胞子 -= Time.deltaTime;
            }
            if (時間釋放胞子 <= 0)
            {
                時間釋放胞子 = 5.0f;
            }

            //釋放時間
            /*
            if (時間釋放胞子 > 3.0f && 時間釋放胞子 < 3.01f || 時間釋放胞子 > 0f && 時間釋放胞子 < 0.01f)
            {
                Vector3 胞子口pos = this.transform.position + new Vector3(0, 0, 0);
                Instantiate(SporeAttack, 胞子口pos, transform.rotation);
            }

            if(時間釋放胞子<1.5f && 時間釋放胞子>1)
            {
                時間控制隨機開關射擊 = true;
            }
            else
            {
                時間控制隨機開關射擊 = false;
            }

            if(時間控制隨機開關射擊)
            {
               亂碼 =  Random.Range(亂數最小值, 亂數最大值);
            }
            else if(!時間控制隨機開關射擊)
            {
                亂碼 = 0;
            }

            if(亂碼 == 幸運數字開炮)
            {
                Vector3 胞子口pos = this.transform.position + new Vector3(0, 0, 0);
                Instantiate(SporeAttack, 胞子口pos, transform.rotation);
            }

        }
          */
    }
