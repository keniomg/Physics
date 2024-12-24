using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private JointMasterInput _jointMasterInput;
    [SerializeField] private float _pushForce;
    [SerializeField] private Rigidbody _swingRigidbody;

    private void OnEnable()
    {
        _jointMasterInput.PushForwardKeyPressed += PushForward;
        _jointMasterInput.PushBackKeyPressed += PushBack;
    }

    private void OnDisable()
    {
        _jointMasterInput.PushForwardKeyPressed -= PushForward;
        _jointMasterInput.PushBackKeyPressed -= PushBack;
    }

    private void PushForward()
    {
        _swingRigidbody.AddForce(Vector3.right * _pushForce, ForceMode.Force);
    }

    private void PushBack()
    {
        _swingRigidbody.AddForce(Vector3.left * _pushForce, ForceMode.Force);
    }
}