using UnityEngine;

public class MoveLeft : MonoBehaviour {

    [SerializeField] float speed;
    void Update() {
        transform.Translate(Time.deltaTime * speed * Vector3.left);
    }
}
