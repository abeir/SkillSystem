using SkillSystem.Character;
using UnityEngine;

public class EnemyController : SkillCharacter
{
    private void OnEnable()
    {
        characterResource.HealthEmptyAction += OnHealthEmpty;
        characterResource.EnergyEmptyAction += OnEnergyEmpty;
    }

    private void OnDisable()
    {
        characterResource.HealthEmptyAction -= OnHealthEmpty;
        characterResource.EnergyEmptyAction -= OnEnergyEmpty;
    }


    private void OnHealthEmpty()
    {
        Debug.Log("---- EnemyController.OnHealthEmpty");
        Destroy(gameObject, 2f);
    }

    private void OnEnergyEmpty()
    {
        Debug.Log("---- EnemyController.OnEnergyEmpty");
    }
}