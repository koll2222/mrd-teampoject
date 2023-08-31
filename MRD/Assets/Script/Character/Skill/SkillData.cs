using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill Data", menuName = "Scriptable Object/Skill Data", order = 1)]

public class SkillData : ScriptableObject
{
    public string m_name;

    public int m_numberOfTarget;

    public float m_damagePercentage;

    public int m_strokes;
}
