using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChange : MonoBehaviour
{
    public GameObject firstUI;
    public GameObject secondUI;
    public GameObject myUI;

    private GameObject originalObject;
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

    private GameObject posObj;
    private Vector3 UIPos;
    public GameObject boxParent;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("a key was pressed.");
            if (originalObject != null)      //첫 ui 등장:상대정보 (위치는 랜덤이긴 함,,)
            {
                //posObj = GameObject.Find("FaceBox1");
                posObj = boxParent.transform.GetChild(0).gameObject;    //첫번째 박스 오브젝트 가져오기
                UIPos = posObj.transform.position;                      //박스 오브젝트 위치 받아오기
                var otherUI = Instantiate(firstUI, UIPos, posObj.transform.rotation);  //UI생성&띄우기
                otherUI.name = "UI1";
                boxParent.SetActive(false); //그동안 생긴 박스 인스턴스들 다 안보이게
                gameObject.GetComponent<FaceDetection>().enabled = false;   //얼굴인식 비활성화
            }
            
        }

        if (Input.GetKeyDown(KeyCode.S))    //상대정보조작
        {
            Debug.Log("s key was pressed.");
            posObj = GameObject.Find("UI1");
            UIPos = posObj.transform.position;
            var anotherUI = Instantiate(secondUI, UIPos, posObj.transform.rotation);
            anotherUI.name = "UI2";
            GameObject.Find("UI1").SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.D))    //개인정보
        {
            Debug.Log("d key was pressed.");
            posObj = GameObject.Find("UI2");
            UIPos = posObj.transform.position;
            var mymyUI = Instantiate(myUI, UIPos, posObj.transform.rotation);
            mymyUI.name = "UI3";
            GameObject.Find("UI2").SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.F))    //개인정보까지 사라지게~
        {
            GameObject.Find("UI3").SetActive(false);
        }
    }
}
