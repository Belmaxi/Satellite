using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sound",menuName = "Sound")]
public class SoundParameter : ScriptableObject
{
    [Tooltip("ÒôÔ´ËØ²Ä")]
    public List<AudioClip> m_Clip;
}
