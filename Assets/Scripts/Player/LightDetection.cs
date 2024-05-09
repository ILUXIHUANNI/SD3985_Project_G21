using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class LightDetection : MonoBehaviour
{
    public static LightDetection instance;
    public List<GameObject> detectList;
    public List<GameObject> hitList;
    [SerializeField] LayerMask layerMask;

    private void Awake()
    {
        instance = this;
        tagsToCheck = new List<string>() { "SimplePlant", "GhostMonster", "Beholder", "Arrow" };
    }

    List<string> tagsToCheck;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tagsToCheck.Contains(collision.tag))
        {
            detectList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (tagsToCheck.Contains(collision.tag))
        {
            detectList.Remove(collision.gameObject);
        }
    }

    private void Update()
    {
        if (detectList != null)
        {
            hitList.Clear();
            for (int i = 0; i < detectList.Count; i++)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, detectList[i].transform.position - transform.position, (detectList[i].transform.position - transform.position).magnitude, layerMask);
                if (hit.collider.gameObject != null)
                {
                    if (!hitList.Contains(hit.collider.gameObject))
                    {
                        hitList.Add(hit.collider.gameObject);
                    }
                }
            }
        }

        //CheckIfCanSee(detectList[0]);
        //detectList[0].WakeUp();
    }

    public bool CheckIfCanSee(GameObject check)
    {
        return hitList.Exists(element => GameObject.ReferenceEquals(element, check));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        for (int i = 0; i < detectList.Count; i++)
        {
            Vector3 dir = detectList[i].transform.position - transform.position;
            Gizmos.DrawLine(transform.position, transform.position + dir);
        }
    }
}
