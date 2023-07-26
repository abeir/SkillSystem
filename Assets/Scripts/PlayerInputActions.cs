//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Playable"",
            ""id"": ""b15c027e-7f62-4d5a-b1b5-0fd8baeaa66a"",
            ""actions"": [
                {
                    ""name"": ""ReleaseSkill"",
                    ""type"": ""Button"",
                    ""id"": ""df358f8a-1e3a-4ca0-bdcc-b91b566fcf4d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectSkill"",
                    ""type"": ""Button"",
                    ""id"": ""2c3b71e6-e34e-4914-a052-78d577011c95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""45aa8fc6-b4ca-4ae4-8f6f-22ee5dcb7005"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReleaseSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c352aca3-2f03-4bf2-9eb2-e4e9c63ec192"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectSkill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Playable
        m_Playable = asset.FindActionMap("Playable", throwIfNotFound: true);
        m_Playable_ReleaseSkill = m_Playable.FindAction("ReleaseSkill", throwIfNotFound: true);
        m_Playable_SelectSkill = m_Playable.FindAction("SelectSkill", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Playable
    private readonly InputActionMap m_Playable;
    private List<IPlayableActions> m_PlayableActionsCallbackInterfaces = new List<IPlayableActions>();
    private readonly InputAction m_Playable_ReleaseSkill;
    private readonly InputAction m_Playable_SelectSkill;
    public struct PlayableActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayableActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ReleaseSkill => m_Wrapper.m_Playable_ReleaseSkill;
        public InputAction @SelectSkill => m_Wrapper.m_Playable_SelectSkill;
        public InputActionMap Get() { return m_Wrapper.m_Playable; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayableActions set) { return set.Get(); }
        public void AddCallbacks(IPlayableActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayableActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayableActionsCallbackInterfaces.Add(instance);
            @ReleaseSkill.started += instance.OnReleaseSkill;
            @ReleaseSkill.performed += instance.OnReleaseSkill;
            @ReleaseSkill.canceled += instance.OnReleaseSkill;
            @SelectSkill.started += instance.OnSelectSkill;
            @SelectSkill.performed += instance.OnSelectSkill;
            @SelectSkill.canceled += instance.OnSelectSkill;
        }

        private void UnregisterCallbacks(IPlayableActions instance)
        {
            @ReleaseSkill.started -= instance.OnReleaseSkill;
            @ReleaseSkill.performed -= instance.OnReleaseSkill;
            @ReleaseSkill.canceled -= instance.OnReleaseSkill;
            @SelectSkill.started -= instance.OnSelectSkill;
            @SelectSkill.performed -= instance.OnSelectSkill;
            @SelectSkill.canceled -= instance.OnSelectSkill;
        }

        public void RemoveCallbacks(IPlayableActions instance)
        {
            if (m_Wrapper.m_PlayableActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayableActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayableActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayableActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayableActions @Playable => new PlayableActions(this);
    public interface IPlayableActions
    {
        void OnReleaseSkill(InputAction.CallbackContext context);
        void OnSelectSkill(InputAction.CallbackContext context);
    }
}