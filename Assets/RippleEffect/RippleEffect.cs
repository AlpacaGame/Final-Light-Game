using UnityEngine;
using System.Collections;

public class RippleEffect : MonoBehaviour
{
    public AnimationCurve waveform = new AnimationCurve(
        new Keyframe(0.00f, 0.50f, 0, 0),
        new Keyframe(0.05f, 1.00f, 0, 0),
        new Keyframe(0.15f, 0.10f, 0, 0),
        new Keyframe(0.25f, 0.80f, 0, 0),
        new Keyframe(0.35f, 0.30f, 0, 0),
        new Keyframe(0.45f, 0.60f, 0, 0),
        new Keyframe(0.55f, 0.40f, 0, 0),
        new Keyframe(0.65f, 0.55f, 0, 0),
        new Keyframe(0.75f, 0.46f, 0, 0),
        new Keyframe(0.85f, 0.52f, 0, 0),
        new Keyframe(0.99f, 0.50f, 0, 0)
    );

    [Range(0.01f, 1.0f)]
    public float refractionStrength = 0.5f;

    public Color reflectionColor = Color.gray;

    [Range(0.01f, 1.0f)]
    public float reflectionStrength = 0.7f;

    [Range(1.0f, 3.0f)]
    public float waveSpeed = 1.25f;

    [Range(0.0f, 2.0f)]
    public float dropInterval = 0.5f;

    [SerializeField, HideInInspector]
    Shader shader;

    class Droplet
    {
        Vector2 position;
        float time;

        public Droplet()
        {
            time = 1000;
        }

        public void Reset()
        {
            position = new Vector2(Random.value, Random.value);
            time = 0;
        }

        //增加指定位置
        public void Reset(Transform transform)
        {
            position = new Vector2(transform.position.x, transform.position.y);
            time = 0;
        }
        public void Reset(float x, float y)
        {
            position = new Vector2(x, y);
            time = 0;
        }

        public void Update()
        {
            time += Time.deltaTime;
        }

        public Vector4 MakeShaderParameter(float aspect)
        {
            return new Vector4(position.x * aspect, position.y, time, 0);
        }
    }

    Droplet[] droplets;
    Texture2D gradTexture;
    Material material;
    float timer;
    int dropCount;

    void UpdateShaderParameters()
    {
        var c = GetComponent<Camera>();

        material.SetVector("_Drop1", droplets[0].MakeShaderParameter(c.aspect));
        material.SetVector("_Drop2", droplets[1].MakeShaderParameter(c.aspect));
        material.SetVector("_Drop3", droplets[2].MakeShaderParameter(c.aspect));

        material.SetColor("_Reflection", reflectionColor);
        material.SetVector("_Params1", new Vector4(c.aspect, 1, 1 / waveSpeed, 0));
        material.SetVector("_Params2", new Vector4(1, 1 / c.aspect, refractionStrength, reflectionStrength));
    }

    void Awake()
    {
        droplets = new Droplet[3];
        droplets[0] = new Droplet();
        droplets[1] = new Droplet();
        droplets[2] = new Droplet();

        gradTexture = new Texture2D(2048, 1, TextureFormat.Alpha8, false);
        gradTexture.wrapMode = TextureWrapMode.Clamp;
        gradTexture.filterMode = FilterMode.Bilinear;
        for (var i = 0; i < gradTexture.width; i++)
        {
            var x = 1.0f / gradTexture.width * i;
            var a = waveform.Evaluate(x);
            gradTexture.SetPixel(i, 0, new Color(a, a, a, a));
        }
        gradTexture.Apply();

        material = new Material(shader);
        material.hideFlags = HideFlags.DontSave;
        material.SetTexture("_GradTex", gradTexture);

        UpdateShaderParameters();
    }

    public bool EffectCountModel;
    public static int EffectCount = 0;
    public static bool PlayEffect = false;
    
    void Update()
    {
        if(EffectCountModel)
        {
            if (dropInterval > 0 && EffectCount >= 1 && PlayEffect)
            {
                timer += Time.deltaTime;
                while (timer > dropInterval && EffectCount >= 1)
                {
                    Emit();
                    timer -= dropInterval;
                    EffectCount -= 1;
                }
            }
        }
        else
        {
            if (dropInterval > 0)
            {
                timer += Time.deltaTime;
                while (timer > dropInterval)
                {
                    Emit();
                    timer -= dropInterval;
                }
            }
        }
        
        foreach (var d in droplets) d.Update();

        UpdateShaderParameters();
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }

    public void Emit()
    {
        if(TargetModel)
        {
            //droplets[dropCount++ % droplets.Length].Reset(Target);
            droplets[dropCount++ % droplets.Length].Reset(posX, posY);
        }
        else
        {
            droplets[dropCount++ % droplets.Length].Reset();
        }
    }

    //public static Transform Target;
    public bool TargetModel;
    public static float posX;
    public static float posY;
    public static void PlayRippleEffect(int effectCount, float x, float y)
    {
        EffectCount = effectCount;
        //Target.position = new Vector3(x, y, 0);
        posX = x;
        posY = y;
        PlayEffect = true;
        Debug.Log("播放ripple特效");
    }
}
