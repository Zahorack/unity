using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderAll : MonoBehaviour
{

    public Material m_Mat = null;
    [Range(0.01f, 0.2f)] public float m_DarkRange = 0.05f;
    [Range(-2.5f, -1f)] public float m_Distortion = -2f;
    
    int m_ID_Center = 0;
    int m_ID_DarkRange = 0;
    int m_ID_Distortion = 0;
    
    float m_MouseX = 0f;
    float m_MouseY = 0f;

    private float last_score;
    
    GameObject[] gos;
        
    
     //Start is called before the first frame update
    void Start()
    {
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (!SystemInfo.supportsImageEffects)
            enabled = false;
        m_MouseX = m_MouseY = 0;
        m_ID_Center = Shader.PropertyToID ("_Center");
        m_ID_DarkRange = Shader.PropertyToID ("_DarkRange");
        m_ID_Distortion = Shader.PropertyToID ("_Distortion");

        foreach (GameObject player in gos)
        {
            last_score = player.transform.localScale.x;
            m_DarkRange = (float) 0.12;
        }

    }

    void OnRenderImage (RenderTexture sourceTexture, RenderTexture destTexture)
    {
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject player in gos)
        {
            m_Mat.SetVector (m_ID_Center, new Vector4 (m_MouseX, m_MouseY, 0f, 0f));
            
            if (player.transform.localScale.x < 50)
                m_Mat.SetFloat(m_ID_DarkRange, m_DarkRange);

            m_Mat.SetFloat(m_ID_Distortion, m_Distortion);
            Graphics.Blit(sourceTexture, destTexture, m_Mat);
        }
    }
    // Update is called once per frame
    void Update()
    {

        gos = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject player in gos)
        {
            Vector3 target = Camera.main.WorldToScreenPoint(player.transform.position);
            m_MouseX = target.x / Screen.width;
            m_MouseY = target.y / Screen.height;

            if (player.transform.localScale.x > last_score)
            {
                ;
                float dark_increment = 0;

                if (player.transform.localScale.x < 10)
                    dark_increment = (float) (-0.01);
                else if (player.transform.localScale.x < 15)
                    dark_increment = (float) (-0.003);
                else if (player.transform.localScale.x < 20)
                    dark_increment = (float) (-0.0008);
                else if (player.transform.localScale.x < 25)
                    dark_increment = (float) (-0.0007);
                else if (player.transform.localScale.x < 30)
                    dark_increment = (float) (-0.0006);
                else if (player.transform.localScale.x < 35)
                    dark_increment = (float) (-0.0003);
                else if (player.transform.localScale.x < 40)
                    dark_increment = (float) (-0.0001);
                else if (player.transform.localScale.x < 45)
                    dark_increment = (float) (-0.00009);


                m_DarkRange += (float) dark_increment;

                if (player.transform.localScale.x < 30)
                    m_Distortion = (float) (player.transform.localScale.x * (0.0138775) - 1.6938775);

                last_score = player.transform.localScale.x;
            }
        }
    }

}
