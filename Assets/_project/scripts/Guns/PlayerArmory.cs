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
        _guns[_curentGunIndex].Deactivate();
        _guns[gunIndex].Activate();
        _curentGunIndex = gunIndex;
    }

    public void AddBullets(int gunIndex, int numverOfBullets)
    {
        _guns[gunIndex].AddBullets(numverOfBullets);
    }
}
