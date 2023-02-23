using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    [SerializeField] private Gun[] _guns;
    [SerializeField] private int _curentGunIndex;
    void Start()
    {
        TakeGunByIndex(_curentGunIndex);
    }

    public void TakeGunByIndex(int gunIndex)
    {
        _curentGunIndex = gunIndex;
        for (int i = 0; i < _guns.Length; i++)
        {
            if (i == gunIndex)
            {
                _guns[i].Activate();
            }
            else
            {
                _guns[i].Deactivate();
            }
        }
    }

    public void AddBullets(int gunIndex, int numverOfBullets)
    {
        _guns[gunIndex].AddBullets(numverOfBullets);
    }
}
