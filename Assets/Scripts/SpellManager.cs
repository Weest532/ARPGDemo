using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    [Header("Spell Slots")]
    public List<SpellData> spellSlots = new List<SpellData>();
    public Player player;

    void Start()
    {
        // Ensure we have exactly 5 spell slots for keys 1-5
        for (int i = spellSlots.Count; i < 5; i++)
        {
            spellSlots.Add(null);
        }

        // Automatic assignment if player is not set in the Inspector
        if (player == null)
        {
            player = FindObjectOfType<Player>();
            if (player == null)
            {
                Debug.LogError("Player object with a Player component not found in the scene!");
            }
        }
    }

    void Update()
    {
        HandleSpellCasting();
    }

    private void HandleSpellCasting()
    {
        for (int i = 0; i < spellSlots.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) && spellSlots[i] != null)
            {
                CastSpell(spellSlots[i]);
            }
        }
    }

    private void CastSpell(SpellData spellData)
    {
        if (spellData.onCooldown) return;

        // Check if the player has enough mana
        if (player != null && player.playerResource >= spellData.manaCost)
        {
            // Raycast from the camera to get the point on the ground where the mouse is pointing
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 targetPoint = hit.point;
                Vector3 direction = (targetPoint - transform.position).normalized;

                // Spawn the specific spell prefab from the SpellData asset
                if (spellData.spellPrefab != null)
                {
                    player.useResource(spellData.manaCost); // Deduct mana
                    Vector3 spawnPosition = transform.position + Vector3.up * 1.5f;
                    GameObject spellInstance = Instantiate(spellData.spellPrefab, spawnPosition, Quaternion.identity);
                    Spell spellComponent = spellInstance.GetComponent<Spell>();
                    if (spellComponent != null)
                    {
                        spellComponent.Initialize(spellData, direction);
                    }
                }

                // Set the spell on cooldown
                spellData.onCooldown = true;
                StartCoroutine(ResetCooldown(spellData));
            }
        }
        else
        {
            Debug.LogWarning("Not enough mana to cast the spell!");
        }
    }

    private IEnumerator ResetCooldown(SpellData spellData)
    {
        yield return new WaitForSeconds(spellData.cooldown);
        spellData.onCooldown = false;
    }
}

