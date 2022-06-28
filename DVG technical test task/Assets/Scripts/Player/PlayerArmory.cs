using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    [SerializeField] private Gun[] _guns;

    [SerializeField] private int _currentGunIndex;

    private void Start()
    {
        TakeGunByIndex(_currentGunIndex);
    }

    public void ChangeWeapon()
    {
        if (_currentGunIndex == 0)
        {
            TakeGunByIndex(1);
        }
        else
        {
            TakeGunByIndex(0);
        }
    }

    private void TakeGunByIndex(int gunIndex)
    {
        _currentGunIndex = gunIndex;
        for (int i = 0; i < _guns.Length; i++)
        {
            if(i == gunIndex)
            {
                _guns[i].Activate();
            }
            else
            {
                _guns[i].Deactivate();
            }
        }
    }
}
