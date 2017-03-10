using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour
{

    public Material InitMaterial;
    public Material SecondMaterial;

    private float duration = 2.0f;
    public bool LerpUpdate = false;

    public int PlatformCollisionLayer = 8;
    public int PlatformNonCollisionLayer = 5;

    private float SwapDuration = 10.0f;
    private float StartTime = 0.0f;

    // Use this for initialization
    void Start()
    {
        //ChangeMaterial();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (LerpUpdate)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            GetComponent<MeshRenderer>().materials[0].Lerp(InitMaterial, SecondMaterial, lerp);
            LerpUpdate = (lerp >= 0.975f) ? (false) : true;

        }

        if (StartTime > 0.0f)
        if (Time.time - StartTime > SwapDuration)
        {
            UpdatePhysics();
        }

    }

    void UpdatePhysics()
    {
        GetComponent<BoxCollider>().isTrigger = !LerpUpdate;
        gameObject.layer = (LerpUpdate) ? PlatformCollisionLayer : PlatformNonCollisionLayer;
    }

    public void ChangeMaterial()
    {
        //print("apksoaf");
        StartTime = Time.time;
        LerpUpdate = true;
        UpdatePhysics();
    }
}
