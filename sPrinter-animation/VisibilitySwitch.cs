using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VisibilitySwitch : MonoBehaviour
{
    // Start is called before the first frame update

    public Button m_button;
    public bool initState = true;
    public GameObject m_object;

    private bool m_state;
    void Start()
    {
        m_button.onClick.AddListener(ButtonHandler);
        m_state = initState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonHandler()
    {
        m_object.SetActive(m_state);
   
        m_state = !m_state;
    }
}
