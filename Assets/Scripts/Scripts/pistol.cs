
using UnityEngine;

public class pistol : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;


   
    void Update()
    {
        
        if (Input.GetKeyDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
       //if ( Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
       // {

       // }
    }
}
