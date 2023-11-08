using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Level : MonoBehaviour
{
    ////////////TO DO///////////////
    //Each Level should calculate their own progress time, the final level should have total time
    //Each Level should have their own button clicked, 
    //Each Level should append their input data to the data vector, the final level should append that data to csv, wrting it
    //Which level should be randomized?
    //Final Level should send signal to watch to end the task process with "off"
    //Should create that tells watch to be off when IMU is not in right position.
    //public int answer;
    //public Material selected;
    //public Material unselected;
    List<Vector3> level_icons;
    int[] map = new int[6];
    //public GameObject[] level_objects;
    List<Vector3> random_icons;

    private float start_time ;
    bool start_level = false;
    List<int> random_idx = new List<int>(6);
    bool last_level = false;
    bool isWaiting = false;
    //private float end_time;
    //public GameObject level_interface;
    //int current_level=0;
    // Start is called before the first frame update

    void Start()
    {
        level_icons = new List<Vector3>();
        random_icons = new List<Vector3>();
        for (int i = 0; i < 6; i++)
        {
            map[i] = 0;
        }
        // for(int i=0;i<6;i++){
        //     if(i==0){
        //         random_idx.Add(0);
        //     }else{
        //         int index=Random.Range(1,6);
        //         while(random_idx.Contains(index)){
        //             index=Random.Range(1,6);
        //         }
        //         random_idx.Add(index);
        //     } 
        // }
        for (int i = 0; i < 6; i++)
        {
            level_icons.Add(new Vector3(0, 0, 0));
            level_icons[i] = this.gameObject.transform.GetChild(i).transform.localPosition;
        }
        // for(int i=0;i<6;i++){
        //     random_icons.Add(new Vector3(0,0,0));
        //     random_icons[i]=level_icons[random_idx[i]];
        //     map[random_idx[i]]=i;
        // }
        // for(int i=0;i<6;i++){
        //     this.gameObject.transform.GetChild(i).gameObject.transform.localPosition=random_icons[i];
        // }

        this.gameObject.SetActive(false);
        //start_level=true;
        //setIconPosition();
        //randomize_icon();
    }
    int onlyonce = 0;
    void randoming()
    {
        start_time = Time.time;
        random_idx = new List<int>(6);
        for (int i = 0; i < 6; i++)
        {
            random_idx.Add(-1);
        }
        random_icons = new List<Vector3>();
        resetPos();
        // for (int i = 0; i < 6; i++)
        // {
        //     level_icons.Add(new Vector3(0, 0, 0));
        //     level_icons[i] = this.gameObject.transform.GetChild(i).gameObject.transform.localPosition;
        // }
        if (LevelManager.instance.current_level == 1)
        {
            for (int i = 0; i < 6; i++)
            {
                int index = Random.Range(0, 6);
                while (random_idx.Contains(index))
                {
                    index = Random.Range(0, 6);
                }
                random_idx[i] = index;
            }
        }
        else if (LevelManager.instance.current_level == 2)
        {
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    random_idx[i] = 0;
                }
                else
                {
                    int index = Random.Range(1, 6);
                    while (random_idx.Contains(index))
                    {
                        index = Random.Range(1, 6);
                    }
                    random_idx[i] = index;
                }
            }
        }
        for (int i = 0; i < 6; i++)
        {
            random_icons.Add(new Vector3(0, 0, 0));
            random_icons[i] = level_icons[random_idx[i]];
            map[random_idx[i]] = i;
        }
        for (int i = 0; i < 6; i++)
        {
            this.gameObject.transform.GetChild(i).transform.localPosition = random_icons[i];
        }
        for (int i = 0; i < 6; i++)
        {
            Debug.Log("Icon Name" + "," + i.ToString() + "," + map[i]);
        }

        Debug.Log("RANDDDDDDOM");
    }
    void resetPos()
    {
        for (int i = 0; i < 6; i++)
        {
            this.gameObject.transform.GetChild(i).transform.localPosition = level_icons[i];
            Debug.Log("Icon Name" + "," + i.ToString() + "," + this.gameObject.transform.GetChild(i).transform.position);
        }
    }
    float level_Time()
    {
        return Time.time - start_time;
    }
    //when level starts, it takes input from the watch...

    bool isRandom = false;
    // Update is called once per frame
    void Update()
    {
    }
}