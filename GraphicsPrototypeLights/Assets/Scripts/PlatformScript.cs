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

    private float SwapDuration = 5.0f;
    private float StartTime = 0.0f;

    // Use this for initialization
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        if (LerpUpdate)
        {
            GetComponent<MeshRenderer>().materials[0].Lerp(InitMaterial, SecondMaterial, duration);

            if (Time.time - StartTime > SwapDuration)
            {
                LerpUpdate = false;
                StartTime = 0.0f;
                UpdatePhysics();
            }

        }
        else
        {
            GetComponent<MeshRenderer>().materials[0].Lerp(SecondMaterial, InitMaterial, duration);
        }

    }

    void UpdatePhysics()
    {
        GetComponent<BoxCollider>().isTrigger = !LerpUpdate;
        gameObject.layer = (LerpUpdate) ? PlatformCollisionLayer : PlatformNonCollisionLayer;
    }

    public void ChangeMaterial()
    {
        StartTime = Time.time;
        LerpUpdate = true;
        UpdatePhysics();
    }
}
