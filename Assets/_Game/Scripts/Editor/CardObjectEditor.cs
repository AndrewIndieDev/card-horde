using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(CardObject))]
public class CardObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CardObject obj = (target as CardObject);

        if (obj.unit != null)
        {
            obj.gameObject.name = string.IsNullOrEmpty(obj.unit.FullName) ? "???" : obj.unit.FullName;

            GUILayout.BeginHorizontal();
            var texture = AssetPreview.GetAssetPreview(obj.unit.artwork);
            GUILayout.Label(texture);

            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Name:", new GUILayoutOption[] { GUILayout.Width(100) });
            GUILayout.Label(obj.unit.namedUnit);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Title:", new GUILayoutOption[] { GUILayout.Width(100) });
            GUILayout.Label(obj.unit.titleSO ? obj.unit.titleSO._suffix : "N/A");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Species:", new GUILayoutOption[] { GUILayout.Width(100) });
            GUILayout.Label(obj.unit.speciesSO ? obj.unit.speciesSO._name : "???");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Health:", new GUILayoutOption[] { GUILayout.Width(100) });
            GUILayout.Label(obj.unit.ModifiedHealth.ToString(), new GUILayoutOption[] { GUILayout.Width(50) });
            GUILayout.Label($"| {(obj.unit.statSO ? obj.unit.HealthModPercent : "100%")}");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Damage:", new GUILayoutOption[] { GUILayout.Width(100) });
            GUILayout.Label(obj.unit.ModifiedDamage.ToString(), new GUILayoutOption[] { GUILayout.Width(50) });
            GUILayout.Label($"| {(obj.unit.statSO ? obj.unit.DamageModPercent : "100%")}");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Decision Time:", new GUILayoutOption[] { GUILayout.Width(100) });
            GUILayout.Label(obj.unit.ModifiedDecisionTime.ToString(), new GUILayoutOption[] { GUILayout.Width(50) });
            GUILayout.Label($"| {(obj.unit.statSO ? obj.unit.DecisionTimeModPercent : "100% ")}");
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Move Speed:", new GUILayoutOption[] { GUILayout.Width(100) });
            GUILayout.Label(obj.unit.ModifiedMoveSpeed.ToString(), new GUILayoutOption[] { GUILayout.Width(50) });
            GUILayout.Label($"| {(obj.unit.statSO ? obj.unit.MoveSpeedModPercent : "100% ")}");
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();

            EditorGUILayout.LabelField("Available Actions:", EditorStyles.boldLabel);
            GUILayout.BeginVertical();
            bool noActions = true;
            if (obj.unit.speciesSO != null && obj.unit.speciesSO._actions != null)
            {
                for (int i = 0; i < obj.unit.speciesSO._actions.Count; i++)
                {
                    if (obj.unit.speciesSO._actions[i] != null)
                    {
                        GUILayout.Label(obj.unit.speciesSO._actions[i].Name + " (species)");
                        noActions = false;
                    }
                }
            }
            if (obj.unit.titleSO != null && obj.unit.titleSO._actions != null)
            {
                for (int i = 0; i < obj.unit.titleSO._actions.Count; i++)
                {
                    if (obj.unit.titleSO._actions[i] != null)
                    {
                        GUILayout.Label(obj.unit.titleSO._actions[i].Name + " (title)");
                        noActions = false;
                    }
                }
            }
            if (noActions)
                GUILayout.Label("None");
            GUILayout.EndVertical();
            obj.UpdateVisuals();
        }
        GUILayout.Space(50);
        base.OnInspectorGUI();
    }
}
