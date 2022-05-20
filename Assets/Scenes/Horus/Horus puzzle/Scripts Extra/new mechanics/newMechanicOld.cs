using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMechanicOld : MonoBehaviour
{
    public float speed;
    [SerializeField] private bool selected = false;
    [SerializeField] private GameObject slot;

    private Vector3 og;
    public Rigidbody rb;
    private Renderer rendererr;
    private Transform trans;
    public bool snapped = false;
    void Start()
    {
        rendererr = GetComponent<Renderer>();
        trans = this.transform;
        og = trans.position;
        rb = gameObject.GetComponent<Rigidbody>();
    }

     void Update()
    {
        if (selected)
        {
            var rayOrigin = trans.position;
            var rayDirection = trans.TransformDirection(Vector3.forward);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
            {
                //Debug.DrawLine(rayOrigin, hitInfo.point, Color.black);
                if (hitInfo.collider.name != slot.name)
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
                else
                {
                    snapped = true;
                    Debug.Log("Win"); 
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            Debug.Log("saw the click");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Debug.Log("Raycast");
                if (hitInfo.collider.gameObject.tag == this.tag)
                {
                    { Debug.Log(gameObject.name+" selected"); }
                    selected = true;
                }

                else { selected = false; }

            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            trans.position = og;
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
