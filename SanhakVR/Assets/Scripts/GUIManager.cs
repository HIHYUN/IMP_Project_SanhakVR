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
    private bool flag = false;

    private bool isLeftInit = false;
    private bool isRightInit = false;

    private GameObject obj_UI = null;
    private GameObject obj_start = null;

    
    private void Start () 
    {
        IsStartStage();
    }

    public void HandInit(HandPresence hand)
    {
        if (hand.name == "LeftHandPresence")
            isLeftInit = true;
        else
            isRightInit = true;

        ButtonHandler.Add(hand);
        hand.ButtonPress.AddListener(OnButtonEvent);
    }

    public bool IsInit()
    {
        return isLeftInit && isRightInit;
    }
    
    void IsStartStage() {

        if (Prefab_Start != null && obj_start == null) {

            obj_start = Prefab_Start;
            Prefab_Start.gameObject.SetActive(true);
            flag = true;

        }
    }
    void OnButtonEvent(char input)
    {
        print(input);

        ButtonInspector = input;
        if (input != ' ' && obj_start != null)
        {
            Destroy(obj_start);
            flag = false;

        }
        
        if (input == 'A' && !flag)
        {
            if (obj_UI == null) 
                obj_UI = Instantiate(Prefab_UI);
            
            else
                Destroy(obj_UI);    
            
        }

        if (input == 'X' && !flag)
        {

            SoundManager.Instance.EffectVolumeMove(-Time.deltaTime * 0.1f);
        }

        if (input == 'Y' && !flag)
        {
            SoundManager.Instance.EffectVolumeMove(+Time.deltaTime * 0.1f);
        }
    }
    public void Clear () 
    {
        Prefab_Clear.gameObject.SetActive(true);
        Invoke("NextStage", 5.0f);

    }

    void NextStage () 
    {
        StageController.Instance.MoveNext();
    }

}
