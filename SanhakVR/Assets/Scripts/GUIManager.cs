using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class GUIManager : MonoBehaviour
{

    public List<HandPresence> ButtonHandler = new List<HandPresence>();
    public char ButtonInspector = ' ';
    public GameObject Prefab_UI;
    public GameObject Prefab_Start;
    public GameObject Prefab_Clear;
    public GameObject Prefab_Setting;
    private bool flag = false;

    private GameObject obj_UI;
    private GameObject obj_menu;
    private GameObject obj_start;

    
    private void Start () {
        
        
        isStartStage();
        foreach(HandPresence b in ButtonHandler) {

            b.ButtonPress.AddListener(onButtonEvent);

        }

    }
    
    private void Update () {

    }
    
    void isStartStage() {

        if (Prefab_Start != null && obj_start == null) {

            obj_start = Instantiate(Prefab_Start);
            flag = true;

        }
    }
    void onButtonEvent(char input) {

        ButtonInspector = input;
        if (input != ' ' && obj_start != null) {

            Destroy(obj_start);
            flag = false;

        }
        
        if (input == 'A' && !flag) {

            if (obj_UI == null) obj_UI = Instantiate(Prefab_UI);
            if (obj_UI != null) Destroy(obj_UI);
            
        }
        if (input == 'B' && !flag) {

            if (obj_menu == null) obj_menu = Instantiate(Prefab_Setting);
            if (obj_menu != null) Destroy(obj_menu);

        }

    }
    void Clear () {

        Instantiate(Prefab_Clear);
        Invoke("NextStage", 5.0f);

    }

    void NextStage () {

        // GameManger ->

    }

}
