using System.Collections.Generic;
using SkillSystem;
using SkillSystem.Character;
using SkillSystem.Controller;
using UnityEngine;

public class CubeSkillController : SkillController
{
    
    public Vector3 targetPos;

    public float speed;

    private void Awake()
    {
        targetPos = GameObject.FindGameObjectWithTag("Test").transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        transform.LookAt(targetPos, Vector3.up);

    }
    
    
    public override void OnSkillImpactStart(SkillRuntime skill, string impactName, List<SkillCharacter> targets)
    {
        Debug.Log(">>>>> CubeSkillController.OnSkillImpactStart");
        gameObject.SetActive(false);
    }

    public override void OnSkillImpactEnd(SkillRuntime skill, string impactName, List<SkillCharacter> targets)
    {
        Debug.Log(">>>>> CubeSkillController.OnSkillImpactEnd");
        Destroy(gameObject);
    }

    public override void OnDetectStart(SkillRuntime skill)
    {
        Debug.Log(">>>>> CubeSkillController.OnDetectStart");
    }

    public override void OnDetectExpired()
    {
        Debug.Log(">>>>> CubeSkillController.OnDetectExpired");
        Destroy(gameObject);
    }
}