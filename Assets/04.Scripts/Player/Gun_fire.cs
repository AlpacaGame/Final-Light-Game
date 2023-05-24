﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_fire : MonoBehaviour
{
    public int 彈匣 = 8;
    public static int 子彈 = 8;
    public int 觀看子彈數量;
    public static int 手槍彈匣數量, 步槍彈匣數量 = 2;
    public bool 填充子彈 = false;

    public float 開火時間 = 1.5f;
    public float 下一槍;

    public GameObject 子彈預設物;

    public GameObject 彈殼動畫;

    //public GameObject 左槍口, 右槍口;

    public GameObject 槍口亮光;

    public static bool 可開火開關 = true;

    public  bool 跳板機 = false;

    public bool 偵測一開始拿的是哪一把 = true;

    [Space(5)]
    [Header("無限子彈模式")]

    public bool InfiniteAmmoModel = false;

    [Header("Raycast物件")]
    public Transform firePoint;
    public int damage = 20;
    public LineRenderer lineRenderer;
    public float impactForce = 20f;
    public GameObject bloodEffect;
    public int layerMask;//射線圖層遮罩

    [Space(5)]
    [Header("超高攻擊模式")]
    public bool SuperDamageModel = false;
    public int SuperDamage = 200;

    [Space(5)]
    [Header("步槍")]
    public bool rifleMode;//可切換步槍時開啟
    public static int currentWeapon = 0;//目前切換到的武器編號
    public float rifleFireRate = 0.1f;
    private float rifleNextFire = 0.0f;
    public static int rifleAmmo;
    public int rifleAmmoNum = 20;

    public static int 切換武器編號;
    
    void Start()
    {
        rifleMode = true;
        rifleFireRate = 0.1f;
        rifleAmmo = rifleAmmoNum;
        /*
        if (InfiniteAmmoModel)
        {
            彈匣數量 += 10000;
        }
        */
    }

    void Update()
    {
        觀看子彈數量 = 子彈;
        切換武器編號 = currentWeapon; //currentWeapon = 0手槍, = 1步槍, =2精神(未實裝)

        if (GameManager.擁有手槍 && 偵測一開始拿的是哪一把)
        {
            currentWeapon = 0;
            偵測一開始拿的是哪一把 = false;
        }
        if (GameManager.擁有步槍 && 偵測一開始拿的是哪一把)
        {
            currentWeapon = 1;
            偵測一開始拿的是哪一把 = false;
        }


        //按下Q鍵，切換武器(步槍&手槍)
        if (rifleMode && Input.GetKeyDown(KeyCode.Q) && GameManager.擁有手槍 && GameManager.擁有步槍)
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
            damage = 20; //子彈傷害

            //按下R鍵，裝子彈
            if (手槍彈匣數量 >= 1 && Input.GetKeyDown(KeyCode.R) && 可開火開關)
            {
                跳板機 = false;
                SoundManager.instance.ReloadSource();
                子彈 = 彈匣;
                手槍彈匣數量 -= 1;
            }

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
                ScreenShake.instance.StartShake(.5f , .05f);
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
                ScreenShake.instance.StartShake(.5f, .05f);
            }
            //沒子彈跳槍機
            else if (子彈 == 0 && Input.GetMouseButtonDown(0))
            {
                //子彈 -= 1;
                跳板機 = true;
                SoundManager.instance.No_BulletsSource();
            }
            //按左鍵裝子彈
            if (子彈 == 0 && Input.GetMouseButtonDown(0) && 跳板機 && 手槍彈匣數量 >= 1)
            {
                跳板機 = false;
                子彈 = 彈匣;
                手槍彈匣數量 -= 1;
                SoundManager.instance.ReloadSource();
            }
        }
        //步槍
        else if (currentWeapon == 1)
        {
            damage = 25; //子彈傷害

            //按下R鍵，裝子彈
            if (步槍彈匣數量 >= 1 && Input.GetKeyDown(KeyCode.R) && 可開火開關)
            {
                跳板機 = false;
                SoundManager.instance.ReloadSource();
                rifleAmmo = rifleAmmoNum;
                步槍彈匣數量 -= 1;

            }

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
                ScreenShake.instance.StartShake(.5f, .2f);
            }
            //裝子彈聲音
            else if (rifleAmmo == 0 && Input.GetMouseButtonDown(0) && Time.time > rifleNextFire)
            {
                跳板機 = true;
                //rifleAmmo -= 1;
                SoundManager.instance.No_BulletsSource();
            }
            //裝子彈
            if (rifleAmmo == 0 && Input.GetMouseButtonDown(0) && 跳板機 && 步槍彈匣數量 >= 1)
            {
                跳板機 = false;
                SoundManager.instance.ReloadSource();
                rifleAmmo = rifleAmmoNum;
                步槍彈匣數量 -= 1;
            }
        }
    }

    IEnumerator RayShoot()
    {
        layerMask = (1 << LayerMask.NameToLayer("Enemy")) | (1 << LayerMask.NameToLayer("EnemyDead")) | (1 << LayerMask.NameToLayer("floor")) | (1 << LayerMask.NameToLayer("Shootable"));//指定可射擊圖層
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, 1000, layerMask);

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
            else if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("EnemyDead"))
            {
                SoundManager.instance.BloodSource();
                Instantiate(bloodEffect, hitInfo.point, Quaternion.identity);
                hitInfo.rigidbody.AddForce(-hitInfo.normal * impactForce);
            }
            else if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Shootable"))
            {
                //隨機破碎聲
                /*
                int ran = Random.Range(0, 1);
                if(ran == 0)
                {
                    SoundManager.instance.Glass1Source();
                }
                else
                {
                    SoundManager.instance.Glass2Source();
                }
                */
                SoundManager.instance.Glass2Source();
                //Instantiate(bloodEffect, hitInfo.point, Quaternion.identity);
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

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;
    }
}