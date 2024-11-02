using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Species", menuName = "Card System/Species")]
public class SpeciesSO : ScriptableObject, IStatModifier
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

    [Header("Species Info")]
    public string _name;
    [TextArea(3, 10)]
    public string _description;
    public Sprite _borderArtwork;
    public List<ActionSO> _actions = new();
}

public struct Species
{
    public string Name;
    public string Description;
    public Sprite BorderArtwork;
    public float HealthModifier;
    public float DamageModifier;
    public float DecisionSpeedModifier;
    public float MoveSpeedModifier;
    public List<ActionSO> Actions;

    public Species(SpeciesSO species)
    {
        Name = species._name;
        Description = species._description;
        BorderArtwork = species._borderArtwork;
        HealthModifier = species.HealthModifier;
        DamageModifier = species.DamageModifier;
        DecisionSpeedModifier = species.DecisionSpeedModifier;
        MoveSpeedModifier = species.MoveSpeedModifier;
        
        Actions = new();
        Actions.AddRange(species._actions);
    }
}