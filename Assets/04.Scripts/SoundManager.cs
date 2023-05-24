using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("玩家音效")]
    public AudioSource Player_audioSource;
    public AudioClip Fire, Reload, No_Bullets, FlashLightOn, FlashLightOff, Pant , PickUp , Move, Glass1, Glass2;
    [Header("敵人音效")]
    public AudioSource Enemy_audioSource;
    //public AudioClip Enemy_Idle, Enemy_Attack, Enemy_Hurt, Enemy_Death;
    public AudioClip Enemy_Attack, Blood , Drop;
    [Header("敵人Boos音效")]
    public AudioSource EnemyBoos_audioSource;
    //public AudioClip EnemyBoos_Idle, EnemyBoos_Attack, EnemyBoos_Attack2, EnemyBoos_Roar, EnemyBoos_Hurt, EnemyBoos_Death;
    public AudioClip EnemyBoos_Attack, EnemyBoos_Attack2, EnemyBoos_Move, EnemyBoss_Death, EnemyBoos_Explosion;

    [Header("系統音效")]
    public AudioSource System_audioSource;
    public AudioClip ButtonClick, FalseAnswer, StartButton;
    [Header("背景音樂")]
    public AudioSource Background_audioSource;
    public AudioClip Menu_Bgm,Background_Source, Boosfight;

    public static float Sound = 1f;
    public static float Music = 0f;

    public static bool MuteSound, MuteMusic = false;
    public static bool musicToggle;

    // Start is called before the first frame update

    void Awake()
    {
        
    }

    void Start()
    {
        /*
        Player_audioSource = GetComponent<AudioSource>();
        Enemy_audioSource = GetComponent<AudioSource>();
        EnemyBoos_audioSource = GetComponent<AudioSource>();

        Background_audioSource = GetComponent<AudioSource>();
        */

        Sound = Player_audioSource.volume;
        Sound = Enemy_audioSource.volume;
        Sound = EnemyBoos_audioSource.volume;
        Sound = System_audioSource.volume;

        Music = Background_audioSource.volume;

        Player_audioSource.volume = 0;
        Enemy_audioSource.volume = 0;
        EnemyBoos_audioSource.volume = 0;
        System_audioSource.volume = 0;

        Background_audioSource.volume = 0;
        //MuteSound,MuteMusic = false;

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        操控音效();
        操控音樂();
        靜音音效();
        靜音音樂();
        暫停音樂音效();
    }

    void 操控音效()
    {
        Player_audioSource.volume = Sound;
        Enemy_audioSource.volume = Sound;
        EnemyBoos_audioSource.volume = Sound;
        System_audioSource.volume = Sound;
    }

    void 操控音樂()
    {
        Background_audioSource.volume = Music;
    }
    /*
    public void 操控音效(float Volume)
    {
        Player_audioSource.volume = Volume;
        Enemy_audioSource.volume = Volume;
        EnemyBoos_audioSource.volume = Volume;
        System_audioSource.volume = Volume;
    }
    
    public void 操控音樂(float Volume)
    {
        Background_audioSource.volume = Volume;
    }
    */

    public void 靜音音效()
    {
        //MuteSound = !MuteSound;
        if (MuteSound)
        {
            Sound = Player_audioSource.volume;
            Sound = Enemy_audioSource.volume;
            Sound = EnemyBoos_audioSource.volume;

            Player_audioSource.volume = 0;
            Enemy_audioSource.volume = 0;
            EnemyBoos_audioSource.volume = 0;
            System_audioSource.volume = 0;
        }
        else //選擇
        {
            Player_audioSource.volume = Sound;
        }       
    }

    public void 靜音音樂()
    {
        //MuteMusic = !MuteMusic;
        if (MuteMusic)
        {
            Music = Background_audioSource.volume;

            Background_audioSource.volume = 0;

        }
        else
        {
            Background_audioSource.volume = Music;
        }
    }

    public void 暫停音樂音效()
    {
         
        if (!musicToggle)
        {
            // 如果音樂已經暫停，則繼續播放
            Background_audioSource.UnPause();

        }
        else
        {
            // 如果音樂正在播放，則暫停
            Background_audioSource.Pause();

        }
    }

    //玩家音效區域
    /// <summary>
    /// 玩家開火音效
    /// </summary>
    public void FireSource()
    {
        Player_audioSource.clip = Fire;
        Player_audioSource.Play();
    }
    /// <summary>
    /// 玩家裝填音效
    /// </summary>
    public void ReloadSource()
    {
        Player_audioSource.clip = Reload;
        Player_audioSource.Play();
    }
    /// <summary>
    /// 玩家沒子彈音效
    /// </summary>
    public void No_BulletsSource()
    {
        Player_audioSource.clip = No_Bullets;
        Player_audioSource.Play();
    }
    /// <summary>
    /// 玩家手電筒開音效
    /// </summary>
    public void FlashLightOnSource()
    {
        Player_audioSource.clip = FlashLightOn;
        Player_audioSource.Play();
    }
    /// <summary>
    /// 玩家手電筒關音效
    /// </summary>
    public void FlashLightOffSource()
    {
        Player_audioSource.clip = FlashLightOff;
        Player_audioSource.Play();
    }
    /// <summary>
    /// 玩家喘氣音效
    /// </summary>
    public void PantSource()
    {
        Player_audioSource.clip = Pant;
        Player_audioSource.Play();
    }
    /// <summary>
    /// 玩家撿拾道具音效
    /// </summary>
    public void PickUpSource()
    {
        Player_audioSource.clip = PickUp;
        Player_audioSource.Play();
    }
    
    /// <summary>
    /// 玩家移動音效
    /// </summary>
    public void MoveSource()
    {
        Player_audioSource.clip = Move;
        Player_audioSource.Play();
    }

    /// <summary>
    /// 東西碎裂音效1
    /// </summary>
    public void Glass1Source()
    {
        Player_audioSource.clip = Glass1;
        Player_audioSource.Play();
    }

    /// <summary>
    /// 東西碎裂音效2
    /// </summary>
    public void Glass2Source()
    {
        Player_audioSource.clip = Glass2;
        Player_audioSource.Play();
    }

    //敵人音效區域
    /*
    /// <summary>
    /// 敵人待機音效
    /// </summary>
    public void Enemy_IdleSource()
    {
        Enemy_audioSource.clip = Enemy_Idle;
        Enemy_audioSource.Play();
    }
    */

    /// <summary>
    /// 敵人攻擊音效
    /// </summary>
    public void Enemy_AttackSource()
    {
        Enemy_audioSource.clip = Enemy_Attack;
        Enemy_audioSource.Play();
    }

    /// <summary>
    /// 敵人被射音效
    /// </summary>
    public void BloodSource()
    {
        Enemy_audioSource.clip = Blood;
        Enemy_audioSource.Play();
    }
    
    /// <summary>
    /// 敵人被射音效
    /// </summary>
    public void DropdSource()
    {
        Enemy_audioSource.clip = Drop;
        Enemy_audioSource.Play();
    }
    /*
    /// <summary>
    /// 敵人受傷音效
    /// </summary>
    public void Enemy_HurtSource()
    {
        Enemy_audioSource.clip = Enemy_Hurt;
        Enemy_audioSource.Play();
    }
    /// <summary>
    /// 敵人死亡音效
    /// </summary>
    public void Enemy_DeathSource()
    {
        Enemy_audioSource.clip = Enemy_Death;
        Enemy_audioSource.Play();
    }
    */
    //敵人Boos音效區域
    /*
    /// <summary>
    /// 敵人Boos待機音效
    /// </summary>
    public void EnemyBoos_IdleSource()
    {
        EnemyBoos_audioSource.clip = EnemyBoos_Idle;
        EnemyBoos_audioSource.Play();
    }
    */
    /// <summary>
    /// 敵人Boos攻擊音效
    /// </summary>
    public void EnemyBoos_AttackSource()
    {
        EnemyBoos_audioSource.clip = EnemyBoos_Attack;
        EnemyBoos_audioSource.Play();
    }

    public void EnemyBoos_AttackSource2()
    {
        EnemyBoos_audioSource.clip = EnemyBoos_Attack2;
        EnemyBoos_audioSource.Play();
    }

    public void EnemyBoos_MoveSource()
    {
        EnemyBoos_audioSource.clip = EnemyBoos_Move;
        EnemyBoos_audioSource.Play();
    }

    public void EnemyBoss_DeathSource()
    {
        EnemyBoos_audioSource.clip = EnemyBoss_Death;
        EnemyBoos_audioSource.Play();
    }
    public void EnemyBoss_ExplosionSource()
    {
        EnemyBoos_audioSource.clip = EnemyBoos_Explosion;
        EnemyBoos_audioSource.Play();
    }
    /*
    /// <summary>
    /// 敵人Boos攻擊2音效
    /// </summary>
    public void EnemyBoos_Attack2Source()
    {
        EnemyBoos_audioSource.clip = EnemyBoos_Attack2;
        EnemyBoos_audioSource.Play();
    }
    /// <summary>
    /// 敵人Boos怒吼音效
    /// </summary>
    public void EnemyBoos_RoarSource()
    {
        EnemyBoos_audioSource.clip = EnemyBoos_Roar;
        EnemyBoos_audioSource.Play();
    }
    /// <summary>
    /// 敵人Boos受傷音效
    /// </summary>
    public void EnemyBoos_HurtSource()
    {
        EnemyBoos_audioSource.clip = EnemyBoos_Hurt;
        EnemyBoos_audioSource.Play();
    }
    /// <summary>
    /// 敵人Boos死亡音效
    /// </summary>
    public void EnemyBoos_DeathSource()
    {
        EnemyBoos_audioSource.clip = EnemyBoos_Death;
        EnemyBoos_audioSource.Play();
    }
    */

    //遊戲系統音效區域
    /// <summary>
    /// 系統按下密碼鎖音效
    /// </summary>
    public void ButtonClickSource()
    {
        System_audioSource.clip = ButtonClick;
        System_audioSource.Play();
    }
    /// <summary>
    /// 系統按下密碼鎖輸入錯誤
    /// </summary>
    public void FalseAnswerSource()
    {
        System_audioSource.clip = FalseAnswer;
        System_audioSource.Play();
    }

    public void StartButtonSource()
    {
        System_audioSource.clip = StartButton;
        System_audioSource.Play();
    }
    //遊戲背景音樂區域
    /// <summary>
    /// 恐怖音樂01
    /// </summary>
    public void Background_SourceMusic()
    {
        Background_audioSource.clip = Background_Source;
        Background_audioSource.Play();
    }
    
    public void Boosfight_SourceMusic()
    {
        Background_audioSource.clip = Boosfight;
        Background_audioSource.Play();
    }
    
    public void Menu_Bgm_SourceMusic()
    {
        Background_audioSource.clip = Menu_Bgm;
        Background_audioSource.Play();
    }
}
