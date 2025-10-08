using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour {

    [SerializeField] float bound;
    
    
    void Update()
    {
        if (Mathf.Abs(transform.position.y) > bound ||
            Mathf.Abs(transform.position.x) > bound ||
            Mathf.Abs(transform.position.z) > bound) {
            Destroy(gameObject);
        }
    }
}
