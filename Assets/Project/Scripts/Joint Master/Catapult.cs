using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private SpringJoint _launcherJoint;
    [SerializeField] private SpringJoint _loaderJoint;
    [SerializeField] private Transform _projectilePlace;
    [SerializeField] private Rigidbody _projectile;
    [SerializeField] private JointMasterInput _catapultInput;
    [SerializeField] private Transform _spoon;
    [SerializeField] private float _loadMinimumAngle = 10;
    [SerializeField] private float _loadMaximumAngle = 15;
    [SerializeField] private float _defaultLauncherForce = 50;

    private float _defaultLoaderForce;

    private void Awake()
    {
        _defaultLoaderForce = _loaderJoint.spring;
        _launcherJoint.spring = 0;
    }

    private void Update()
    {
        HandleProjectileClamp();
    }

    private void OnEnable()
    {
        _catapultInput.LaunchKeyPressed += LaunchProjectile;
        _catapultInput.ReloadKeyPressed += LoadProjectile;
    }

    private void OnDisable()
    {
        _catapultInput.LaunchKeyPressed -= LaunchProjectile;
        _catapultInput.ReloadKeyPressed -= LoadProjectile;
    }

    private void LaunchProjectile()
    {
        _loaderJoint.spring = 0;
        _launcherJoint.spring = _defaultLauncherForce;
        _loaderJoint.connectedBody.WakeUp();
    }

    private void LoadProjectile()
    {
        _launcherJoint.spring = 0;
        _loaderJoint.spring = _defaultLoaderForce;
        _loaderJoint.connectedBody.WakeUp();
    }

    private void HandleProjectileClamp()
    {
        if (_spoon.gameObject.transform.localEulerAngles.z >= _loadMinimumAngle && _spoon.gameObject.transform.localEulerAngles.z <= _loadMaximumAngle)
        {
            _projectile.transform.position = _projectilePlace.position;
        }
    }
}