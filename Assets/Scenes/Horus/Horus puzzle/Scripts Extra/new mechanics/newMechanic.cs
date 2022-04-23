using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMechanic : MonoBehaviour
{
    public float speed;
   [SerializeField] private bool selected = false;
  

    public Rigidbody rb;
    private Renderer rendererr;

    void Start()
    {
        rendererr = GetComponent<Renderer>();

        rb = gameObject.GetComponent<Rigidbody>();
    }
     void Update()
    {

        if (selected) 
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = new Vector3(0, 1 * Time.deltaTime * speed, 0);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.velocity = new Vector3(0, -1 * Time.deltaTime * speed, 0);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                rb.velocity = new Vector3(1 * Time.deltaTime * speed, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                rb.velocity = new Vector3(-1 * Time.deltaTime * speed, 0, 0);
            }
        }

     
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Object1")
                {
                   
                    { Debug.Log("Oject1 selected"); }

                    selected = true;
                }

                else { selected = false; }

            }
        }
    }
    private void OnMouseEnter()
    {
        rendererr.material.color = Color.red;

    }
    private void OnMouseExit()
    {
        rendererr.material.color = Color.yellow;
    }

}
