using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] List<Stats> playerAbilities = new List<Stats>();
    Abilities abilities;
    public void AddElement(Stats newStat)
    {
        playerAbilities.Add(newStat);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
