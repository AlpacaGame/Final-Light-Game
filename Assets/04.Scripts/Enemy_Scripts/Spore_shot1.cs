using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spore_shot1 : MonoBehaviour
{
    //參考天璇
    public Quaternion InitAngle;

    public int 子彈消失時間 = 1;

    public bool IsFloor = false;





    //參考陳間時光

    [Space(5)]
    [Header("初始隨機移動速度")]

    public float StartSpeedX = 5.5f;
    public float StartSpeedY = 5.5f;

    [Header("隨機增加上限")]
    public float RandomPlusSpeedMaxValue = 5.5f;

    private Rigidbody2D Rg2D;

    //胞子炸裂
    public GameObject Spore_TrackAmmo;

    public GameObject 掉落物;

    // Start is called before the first frame update
    void Start()
    {
        Rg2D = GetComponent<Rigidbody2D>();
        Rg2D.velocity = new Vector2(Random.Range(StartSpeedX, StartSpeedX + RandomPlusSpeedMaxValue), Random.Range(StartSpeedY, StartSpeedY + RandomPlusSpeedMaxValue));

        //transform.rotation = InitAngle;

        Destroy(gameObject, 子彈消失時間);
        Invoke("胞子炸裂", 子彈消失時間 - 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector2(0, 0.05f));
        

    }

    //新增追蹤胞子物
    public void 胞子炸裂()
    {
        print("炸開");
        Vector3 追蹤胞子口pos = this.transform.position + new Vector3(0, 0, 0);
        Instantiate(Spore_TrackAmmo, 追蹤胞子口pos, transform.rotation);
    }



    void OnTriggerEnter2D(Collider2D Damage)
    {
        if (Damage.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);

            Vector3 掉落物pos = this.transform.position + new Vector3(0, 0, 0);
            Instantiate(掉落物, 掉落物pos, transform.rotation);
        }

        if (Damage.gameObject.tag == "floor")
        {
            
            IsFloor = true;
            //transform.rotation = Quaternion.Euler(new Vector3(0,0, -transform.rotation.z));
            //transform.Translate(new Vector2(0, -0.05f));
        }
    }

    void OnTriggerExit2D(Collider2D Damage)
    {
        if (Damage.gameObject.tag == "floor")
        {
            IsFloor = false;
        }
    }
}
