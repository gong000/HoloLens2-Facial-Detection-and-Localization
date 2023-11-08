using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChange : MonoBehaviour
{
    public GameObject changeObject;

    public GameObject originalObject;
    // Start is called before the first frame update
    private FaceDetection _faceDetection;

    private void Awake()
    {
        _faceDetection = GameObject.Find("FaceDetector").GetComponent<FaceDetection>();
    }
    
    void Start()
    {
        originalObject = _faceDetection.objectOutlineCube;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key was pressed.");
            _faceDetection.objectOutlineCube = changeObject;

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Space key was pressed.");
            if (originalObject != null)
            {
                _faceDetection.objectOutlineCube = originalObject;
            }
            
        }
    }
}
