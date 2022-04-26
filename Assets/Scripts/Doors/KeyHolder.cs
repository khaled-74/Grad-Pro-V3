using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private static List<Key.keyType> keyList;
    private void Awake()
    {
        keyList = new List<Key.keyType>();
    }

    public void AddKey(Key.keyType _keyType)
    {
        Debug.Log("Added key i keyHolder: " + _keyType);
        keyList.Add(_keyType);
    }

    public void RemoveKey(Key.keyType _keyType)
    {
        Debug.Log("removed key: " + _keyType);
        keyList.Remove(_keyType);
    }

    public bool ContainsKey(Key.keyType _keyType)
    {
        return keyList.Contains(_keyType);
    }

    public bool ContainsKey(List<Key.keyType> _keyType)
    {
        foreach(Key.keyType key in _keyType)
        {
            if (!ContainsKey(key))
                return false;
        }

        return true;
    }
}
