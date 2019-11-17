using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRenderShader : MonoBehaviour
{

    public GameObject player;
    
    public Material m_Mat = null;
    [Range(0.01f, 0.2f)] public float m_DarkRange = 0.05f;
    [Range(-2.5f, -1f)] public float m_Distortion = -2f;
    
    int m_ID_Center = 0;
    int m_ID_DarkRange = 0;
    int m_ID_Distortion = 0;
    
    float m_MouseX = 0f;
    float m_MouseY = 0f;
    
    //Start is called before the first frame update
    void Start()
    {
        if (!SystemInfo.supportsImageEffects)
            enabled = false;
        m_MouseX = m_MouseY = 0;
        m_ID_Center = Shader.PropertyToID ("_Center");
        m_ID_DarkRange = Shader.PropertyToID ("_DarkRange");
        m_ID_Distortion = Shader.PropertyToID ("_Distortion");
        
        Vector3 target = Camera.main.WorldToScreenPoint(player.transform.position);
        m_MouseX = target.x / Screen.width;
        m_MouseY = target.y / Screen.height;
        
        m_Mat.SetVector (m_ID_Center, new Vector4 (m_MouseX, m_MouseY, 0f, 0f));
    }

    void OnRenderImage (RenderTexture sourceTexture, RenderTexture destTexture)
    {
        
        m_Mat.SetFloat (m_ID_DarkRange, m_DarkRange);
        m_Mat.SetFloat (m_ID_Distortion, m_Distortion);
        Graphics.Blit (sourceTexture, destTexture, m_Mat);
    }
    // Update is called once per frame
    void Update()
    {
       /* 
        Vector3 target = Camera.main.WorldToScreenPoint(player.transform.position);
        m_MouseX = target.x / Screen.width;
        m_MouseY = target.y / Screen.height;

        m_DarkRange = (float)(player.transform.localScale.x /(-257.894) + 0.203877);
        m_Distortion = (float)(player.transform.localScale.x *(0.026530) -2.526);
        */
    }
}