using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Title", menuName = "Card System/Title")]
public class TitleSO : ScriptableObject, IStatModifier
{
    public float HealthModifier => _healthModifier;
    public float DamageModifier => _damageModifier;
    public float DecisionSpeedModifier => _decisionSpeedModifier;
    public float MoveSpeedModifier => _moveSpeedModifier;

    [Header("Stat Mods (in %)")]
    [Range(25, 1000)]
    [SerializeField] private float _healthModifier = 100f;
    [Range(25, 1000)]
    [SerializeField] private float _damageModifier = 100f;
    [Range(25, 1000)]
    [SerializeField] private float _decisionSpeedModifier = 100f;
    [Range(25, 1000)]
    [SerializeField] private float _moveSpeedModifier = 100f;

    [Header("Title Settings")]
    public string _suffix;
    public List<ActionSO> _actions = new();
}

public struct Title
{
    public string Suffix;
    public float HealthModifier;
    public float DamageModifier;
    public float DecisionSpeedModifier;
    public float MoveSpeedModifier;
    public List<ActionSO> Actions;

    public Title(TitleSO title)
    {
        Suffix = title._suffix;
        HealthModifier = title.HealthModifier;
        DamageModifier = title.DamageModifier;
        DecisionSpeedModifier = title.DecisionSpeedModifier;
        MoveSpeedModifier = title.MoveSpeedModifier;

        Actions = new();
        Actions.AddRange(title._actions);
    }
}