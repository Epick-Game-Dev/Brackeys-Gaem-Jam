using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue System/Narrator", menuName = "New Narrator Dialogue")]

public class NarratorSO : ScriptableObject
{
    [TextArea] public string narration;
}
