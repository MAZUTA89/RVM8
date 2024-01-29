
using UnityEngine;
[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObjects/Player")]
public class PlayerSO : ScriptableObject
{
    public float Speed;
    public float Gravity;

    [Header("�������� �������� �� �������")]
    public float RotSpeed;
}
