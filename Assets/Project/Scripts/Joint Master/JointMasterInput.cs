using System;
using System.Collections.Generic;
using UnityEngine;

public class JointMasterInput : MonoBehaviour
{
    [SerializeField] private KeyCode _reloadKey;
    [SerializeField] private KeyCode _launchKey;
    [SerializeField] private KeyCode _forwardKey;
    [SerializeField] private KeyCode _backKey;

    private Dictionary<KeyCode, Action> _keyActions = new();

    public event Action ReloadKeyPressed;
    public event Action LaunchKeyPressed;
    public event Action PushForwardKeyPressed;
    public event Action PushBackKeyPressed;

    private void Awake()
    {
        _keyActions = new()
        {
            { _reloadKey, () => ReloadKeyPressed?.Invoke() },
            { _launchKey, () => LaunchKeyPressed?.Invoke() },
            { _forwardKey, () => PushForwardKeyPressed?.Invoke() },
            { _backKey , () => PushBackKeyPressed?.Invoke() }
        };
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        foreach(KeyValuePair<KeyCode, Action> action in _keyActions)
        {
            if (Input.GetKeyDown(action.Key))
            {
                action.Value.Invoke();
                break;
            }
        }
    }
}