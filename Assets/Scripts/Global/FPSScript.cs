using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FPSScript : MonoBehaviour
{
    public float timer, refresh, avgFramerate;
    public string display = "{0} FPS";
    public TMP_Text m_text;
    public Toggle toggleFPS;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;

        if (timer <= 0) avgFramerate = (int)(1f / timelapse);
        m_text.text = string.Format(display, avgFramerate.ToString());
    }

    public void ShowFPS()
    {
        if (toggleFPS.isOn)
            m_text.enabled = true;
        else
            m_text.enabled = false;
    }
}
