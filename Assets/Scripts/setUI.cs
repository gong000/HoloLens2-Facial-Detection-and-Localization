using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _newParent;
    void Start()
    {
        _newParent = GameObject.Find("newparent");
        if (_newParent == null) _newParent = gameObject.transform.parent.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setUIActive()
    {
        gameObject.SetActive(true);
        //하이라키 바꿔주긴
        gameObject.transform.SetParent(_newParent.transform);
    }
}
 