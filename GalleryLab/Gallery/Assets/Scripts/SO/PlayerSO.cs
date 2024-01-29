
using UnityEngine;
[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player")]
public class PlayerSO : ScriptableObject
{
    public float Speed;
    public float Gravity;

    [Header("Скорость поворота за камерой")]
    public float RotSpeed;
}
