using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//check it 
[CreateAssetMenu(menuName ="Scriptable Object/Board/Layout")]
public class BoardLayout : ScriptableObject
{
    [SerializeField]

    private class BoardSquareSetup 
    {
        public Vector2Int position;
    }
}
