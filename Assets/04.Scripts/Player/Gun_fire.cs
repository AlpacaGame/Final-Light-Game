using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_fire : MonoBehaviour
{
    public int 彈匣 = 8;
    public static int 子彈 = 8;
    public int 觀看子彈數量;
    public static int 彈匣數量 = 2;
    public bool 填充子彈 = false;

    public float 開火時間 = 1.5f;
    public float 下一槍;

    public GameObject 子彈預設物;

    public GameObject 彈殼動畫;

    //public GameObject 左槍口, 右槍口;

    public GameObject 槍口亮光;

    public static bool 可開火開關 = true;

    [Space(5)]
    [Header("無限子彈模式")]

    public bool InfiniteAmmoModel = false;

    [Header("Raycast物件")]
    public Transform firePoint;
    public int damage = 20;
    public LineRenderer lineRenderer;
    public float impactForce = 20f;
    public GameObject bloodEffect;

    [Space(5)]
    [Header("超高攻擊模式")]
    public bool SuperDamageModel = false;
    public int SuperDamage = 200;

    [Space(5)]
    [Header("錄影模式")]
    public bool recordModel = false;

    [Space(5)]
    [Header("步槍")]
    public bool rifleMode;//可切換步槍時開啟
    public int currentWeapon = 0;//目前切換到的武器編號
    public float rifleFireRate = 0.1f;
    private float rifleNextFire = 0.0f;
    public int rifleAmmo;
    public int rifleAmmoNum = 20;
    
    void Start()
    {
        rifleMode = true;
        rifleFireRate = 0.1f;
        rifleAmmo = rifleAmmoNum;

        if (InfiniteAmmoModel)
        {
            彈匣數量 += 10000;
        }
    }

    void Update()
    {
        觀看子彈數量 = 子彈;

        //按下R鍵，裝子彈
        if (彈匣數量 >= 1 && Input.GetKeyDown(KeyCode.R) && 可開火開關)
        {
            子彈 = 彈匣;
            彈匣數量 -= 1;
            SoundManager.instance.ReloadSource();
        }

        //按下Q鍵，切換武器(步槍&手槍)
        if(rifleMode && Input.GetKeyDown(KeyCode.Q))
        {
            SoundManager.instance.PickUpSource();
            if (currentWeapon == 0)
            {
                currentWeapon = 1;
            }
            else if (currentWeapon == 1)
            {
                currentWeapon = 0;
            }
        }
 
        //按下滑鼠左鍵射擊
        //手槍
        if (currentWeapon == 0)
        {
            //開火左
            if (子彈 >= 1 && Input.GetMouseButtonDown(0) && 新Pivot.玩家面相 == -1 && 可開火開關)
            {
                Vector3 槍口pos = this.transform.position + new Vector3(0, 0, 0);
                Vector3 槍口後pos = this.transform.position + new Vector3(0.5f, 0, 0);
                StartCoroutine(RayShoot());
                Instantiate(彈殼動畫, 槍口pos, transform.rotation);
                Instantiate(槍口亮光, 槍口pos, transform.rotation);
                子彈 -= 1;
                SoundManager.instance.FireSource();
            }
            //開火右
            else if (子彈 >= 1 && Input.GetMouseButtonDown(0) && 新Pivot.玩家面相 == 1 && 可開火開關)
            {
                Vector3 槍口pos = this.transform.position + new Vector3(0, 0, 0);
                Vector3 槍口後pos = this.transform.position + new Vector3(-0.5f, 0, 0);
                StartCoroutine(RayShoot());
                Instantiate(彈殼動畫, 槍口pos, transform.rotation);
                Instantiate(槍口亮光, 槍口pos, transform.rotation);
                子彈 -= 1;
                SoundManager.instance.FireSource();
            }
            //沒子彈跳槍機
            else if (子彈 == 0 && Input.GetMouseButtonDown(0))
            {
                子彈 -= 1;
                SoundManager.instance.No_BulletsSource();
            }
            //按左鍵裝子彈
            else if (子彈 <= -1 && Input.GetMouseButtonDown(0))
            {
                子彈 = 彈匣;
                彈匣數量 -= 1;
                SoundManager.instance.ReloadSource();
            }
        }
        //步槍
        else if (currentWeapon == 1)
        {
            //開火
            if (rifleAmmo >= 1 && Input.GetMouseButton(0) && 可開火開關 && Time.time > rifleNextFire)
            {
                rifleNextFire = Time.time + rifleFireRate;
                Vector3 槍口pos = this.transform.position + new Vector3(0, 0, 0);
                if(新Pivot.玩家面相 == -1)
                {
                    Vector3 槍口後pos = this.transform.position + new Vector3(0.5f, 0, 0);
                }
                else if(新Pivot.玩家面相 == 1)
                {
                    Vector3 槍口後pos = this.transform.position + new Vector3(-0.5f, 0, 0);
                }
                StartCoroutine(RayShoot());
                Instantiate(彈殼動畫, 槍口pos, transform.rotation);
                Instantiate(槍口亮光, 槍口pos, transform.rotation);
                rifleAmmo -= 1;
                SoundManager.instance.FireSource();
            }
            //按左鍵裝子彈
            else if (rifleAmmo <= 0 && Input.GetMouseButtonDown(0))
            {
                SoundManager.instance.ReloadSource();
                rifleAmmo = rifleAmmoNum;
                //彈匣數量 -= 1;
            }
        }
    }

    IEnumerator RayShoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if(recordModel)
        {
            if (hitInfo)
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point);
                Instantiate(bloodEffect, hitInfo.point, Quaternion.identity);
            }
            else
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
            }
        }
        else
        {
            if (hitInfo)
            {
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    SoundManager.instance.BloodSource();

                    if (SuperDamageModel)
                    {
                        enemy.TakeDamage(SuperDamage);
                    }
                    else
                    {
                        enemy.TakeDamage(damage);
                    }

                    Instantiate(bloodEffect, hitInfo.point, Quaternion.identity);
                    hitInfo.rigidbody.AddForce(-hitInfo.normal * impactForce);
                }
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point);
            }
            else
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
            }
        }
        
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;
    }
}