using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValuesChange : MonoBehaviour
{
    private AudioSource m_audioClip;

    private float m_musicAudio=1f;
    private void Start()
    {
        m_audioClip = GetComponent<AudioSource>();

    }
    private void Update()
    {
        m_audioClip.volume =m_musicAudio;
    }
    public void setvolum(float vol)
    {
        // m_musicAudio = PlayerPrefs.GetFloat(vol);
        m_musicAudio = vol;


    }
}
