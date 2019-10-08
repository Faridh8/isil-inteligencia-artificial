using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    void Update()
    {
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mp.Scale(new Vector3(1, 1, 0));
        transform.position = mp;
        
    }
}
