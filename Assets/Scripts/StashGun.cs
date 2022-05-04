using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StashGun : MonoBehaviour
{
     public GameObject gun;
    public Rigidbody rb;
    public Shoot gunScript;
    public KeyHolder _keyHolder;
    [SerializeField] private List<Key.keyType> _keyType;
    public Transform player, gunContainer, fpsCamera;
    public bool equiped;
    public bool stashed=true;
    public static bool slotFilled;
    // Start is called before the first frame update
    void Start()
    {
        if (!equiped)
        {
             gun.SetActive(false);
            gunScript.enabled = false;
            rb.isKinematic = false;
            Debug.Log("not equiped");
        }
        if(equiped)
        {
            gun.SetActive(true);
            gunScript.enabled = true;
            rb.isKinematic = true;
            slotFilled = true;
            Debug.Log("equiped");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //took the gun & presses q to equip it
        if (!equiped && (_keyHolder.ContainsKey(_keyType) || stashed) && Input.GetKeyDown(KeyCode.E) && !slotFilled)
        { Debug.Log("first if is true"); Equip(); Debug.Log("out of equip"); }
       
        //the gun is equipped & presses q to unequip it
        if (equiped && Input.GetKeyDown(KeyCode.Q))
        { Debug.Log("second if is true"); Unequip(); Debug.Log("out of unequip"); } 
    }

    private void Equip()
    {
        Debug.Log("in equip");
        equiped = true;
        slotFilled = true;

        gun.SetActive(true);

        gun.transform.SetParent(gunContainer);
        gun.transform.localPosition = Vector3.zero;
        gun.transform.localRotation = Quaternion.Euler(Vector3.zero);
        gun.transform.localScale = Vector3.one;

        
        rb.isKinematic = true;

        gunScript.enabled = true;
        
    }

    private void Unequip()
    {
        Debug.Log("in unequip");
        equiped = false;
        slotFilled = false;

        gun.SetActive(false);
        gun.transform.SetParent(null);
       

        rb.isKinematic = false;

        gunScript.enabled = false;
        
    }
}
