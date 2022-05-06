using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LaserBeam 
{
    Vector3 pos, dir;
    GameObject laserObj;
    LineRenderer laser;
    List<Vector3>laserIndices = new List<Vector3>();
    /*[SerializeField]*/ private GameObject actor = GameObject.Find("FP Player(1)");
    /*[SerializeField]*/
    private LevelLoader loader = (LevelLoader)GameObject.FindObjectOfType(typeof(LevelLoader));
    public LaserBeam(Vector3 pos,Vector3 dir,Material material) 
    {
        this.laser = new LineRenderer();
        this.laserObj = new GameObject();
        this.laserObj.name = "Laser Beam";
        this.pos = pos;
        this.dir = dir;

        this.laser=this.laserObj.AddComponent<LineRenderer>() as LineRenderer;
        this.laser.startWidth = 0.1f;
        this.laser.endWidth = 0.1f;
        this.laser.material = material;
        this.laser.startColor = Color.yellow;
        this.laser.endColor = Color.yellow;

        CastRay(pos, dir, laser);
    }
    
    void CastRay(Vector3 pos,Vector3 dir,LineRenderer laser) 
    {
        laserIndices.Add(pos);
        Ray ray = new Ray(pos, dir);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, 1))
        {
            CheckHit(hit,dir,laser);
        }
        else
        {
            laserIndices.Add(ray.GetPoint(100));
            UpdateLaser();
        }
    }

    void UpdateLaser() 
    {
        int count = 0;
        laser.positionCount = laserIndices.Count;
        foreach (Vector3 idx in laserIndices) 
        {
            laser.SetPosition(count, idx);
            count++;
        }
    }
    void CheckHit(RaycastHit hitInfo,Vector3 direction,LineRenderer laser) 
    {
        if (hitInfo.collider.gameObject.tag == "Mirror")
        {
            Vector3 pos = hitInfo.point;
            Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);
            CastRay(pos, dir, laser);
        }
        else if (hitInfo.collider.gameObject.tag =="RA")
        {
            //Win condition
            Debug.Log("You win");
            laserIndices.Add(hitInfo.point);
            UpdateLaser();
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Conv W RA", actor.transform);
            loader.ForRa();
           // SceneManager.LoadScene("Act 3");
        }
        else
        {
            laserIndices.Add(hitInfo.point);
            UpdateLaser();
        }
        
    }
}
