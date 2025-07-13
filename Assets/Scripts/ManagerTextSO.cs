using UnityEngine;

[CreateAssetMenu(fileName = "ManagerTextSO", menuName = "Scriptable Objects/ManagerTextSO")]
public class ManagerTextSO : ScriptableObject
{
    [TextArea] public string Text;
}
