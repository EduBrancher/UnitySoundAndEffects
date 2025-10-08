using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour {
    [SerializeField] GameObject backgroundLeft;
    [SerializeField] GameObject backgroundRight;
    Vector3 startPosLeft;
    Vector3 startPosRight;
    List<GameObject> backgrounds = new List<GameObject>();

    float repeatWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        startPosLeft = backgroundLeft.transform.position;
        startPosRight = backgroundRight.transform.position;
        repeatWidth = backgroundLeft.GetComponent<BoxCollider>().size.x;
        backgrounds.Add(backgroundLeft);
        backgrounds.Add(backgroundRight);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject background in backgrounds) {
            if (background.transform.position.x < startPosLeft.x - repeatWidth) {
                background.transform.position = startPosRight;
            }
        }
    }
}
