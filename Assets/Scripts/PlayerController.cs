using SkillSystem;
using SkillSystem.Character;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : SkillCharacter, PlayerInputActions.IPlayableActions
{

    private PlayerInputActions _inputActions;
    
    protected override void Awake()
    {
        base.Awake();

        _inputActions = new PlayerInputActions();
        _inputActions.Playable.SetCallbacks(this);
    }

    private void OnEnable()
    {
        characterResource.HealthEmptyAction += OnHealthEmpty;
        characterResource.EnergyEmptyAction += OnEnergyEmpty;
        
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        characterResource.HealthEmptyAction -= OnHealthEmpty;
        characterResource.EnergyEmptyAction -= OnEnergyEmpty;
        
        _inputActions.Disable();
    }


    public void OnReleaseSkill(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var skill = SkillManager.CurrentSkill();
            Debug.Log($">>> PlayerController.OnReleaseSkill: {skill?.Base.name}");
            ReleaseSkill();
        }
    }



    private Skill _skill;
    public void OnSelectSkill(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_skill == null)
            {
                _skill = SkillManager.Select(1001);
            }else if (_skill.Base.id == 1001)
            {
                _skill = SkillManager.Select(1002);
            }
            
            Debug.Log($">>> PlayerController.OnSelectSkill: {_skill?.Base.name}");
        }
    }


    private void OnHealthEmpty()
    {
        Debug.Log("---- PlayerController.OnHealthEmpty");
    }

    private void OnEnergyEmpty()
    {
        Debug.Log("---- PlayerController.OnEnergyEmpty");
    }
}
