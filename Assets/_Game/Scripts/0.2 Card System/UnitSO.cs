using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Card System/Unit", order = 1)]
public class UnitSO : ScriptableObject
{
#if UNITY_EDITOR
    public int ModifiedHealth => statSO == null ? stats.ModifiedHealth : Mathf.CeilToInt(statSO.health * (speciesSO == null ? 1 : speciesSO.HealthModifier / 100) * (titleSO == null ? 1 : titleSO.HealthModifier / 100));
    public int ModifiedDamage => statSO == null ? stats.ModifiedDamage : Mathf.CeilToInt(statSO.damage * (speciesSO == null ? 1 : speciesSO.DamageModifier / 100) * (titleSO == null ? 1 : titleSO.DamageModifier / 100));
    public float ModifiedDecisionTime => statSO == null ? stats.ModifiedDecisionTime : statSO.decisionTime * (speciesSO == null ? 1 : speciesSO.DecisionSpeedModifier / 100) * (titleSO == null ? 1 : titleSO.DecisionSpeedModifier / 100);
    public float ModifiedMoveSpeed => statSO == null ? stats.ModifiedMoveSpeed : statSO.moveSpeed * (speciesSO == null ? 1 : speciesSO.MoveSpeedModifier / 100) * (titleSO == null ? 1 : titleSO.MoveSpeedModifier / 100);

    public string HealthModPercent => ((speciesSO == null ? 1 : speciesSO.HealthModifier / 100) * (titleSO == null ? 1 : titleSO.HealthModifier / 100) * 100).ToString("N2") + "%";
    public string DamageModPercent => ((speciesSO == null ? 1 : speciesSO.DamageModifier / 100) * (titleSO == null ? 1 : titleSO.DamageModifier / 100) * 100).ToString("N2") + "%";
    public string DecisionTimeModPercent => ((speciesSO == null ? 1 : speciesSO.DecisionSpeedModifier / 100) * (titleSO == null ? 1 : titleSO.DecisionSpeedModifier / 100) * 100).ToString("N2") + "%";
    public string MoveSpeedModPercent => ((speciesSO == null ? 1 : speciesSO.MoveSpeedModifier / 100) * (titleSO == null ? 1 : titleSO.MoveSpeedModifier / 100) * 100).ToString("N2") + "%";

    public string FullName => $"{(string.IsNullOrEmpty(namedUnit) ? "???" : namedUnit + (titleSO == null ? "" : string.IsNullOrEmpty(titleSO._suffix) ? "" : $" {titleSO._suffix}"))}";
#endif

    [Header("Unit Info")]
    public string namedUnit;
    public Sprite artwork;

    [Header("Unit Settings")]
    public StatSO statSO;
    public SpeciesSO speciesSO;
    public TitleSO titleSO;

    public Stats stats;

    public void Copy(UnitSO other)
    {
        namedUnit = other.namedUnit;
        artwork = other.artwork;
        statSO = ScriptableObject.CreateInstance<StatSO>();
        statSO.Copy(other.statSO);
        speciesSO = other.speciesSO;
        titleSO = other.titleSO;

        Init();
    }

    public void Init()
    {
        stats = new(statSO);
        stats.AddModifiers(speciesSO);
        stats.AddModifiers(titleSO);
        statSO = null;
    }

    public string GetFullName()
    {
        return $"{(string.IsNullOrEmpty(namedUnit) ? "???" : namedUnit)}{(string.IsNullOrEmpty(titleSO._suffix) ? "" : $" {titleSO._suffix}")}";
    }
}
