using UnityEngine;

[CreateAssetMenu(fileName = "NewSpell", menuName = "Spell System/SpellData")]
public class SpellData : ScriptableObject
{
    public string spellName;
    public GameObject spellPrefab; // Prefab for the spell
    public float damage;
    public float range;
    public float cooldown;
    public bool onCooldown;
    public float manaCost;
}
