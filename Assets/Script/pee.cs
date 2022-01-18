using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;


public class pee : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btn_pee;
    public Button btn_jackpot100;
    public Button btn_replay;
    public GameObject btn_pee_obj;
    public GameObject btn_bet;
    public Transform obj_liquid;
    public GameObject txt_score;
    public GameObject replay_panel;
    public GameObject btn_bet_obj;
    public GameObject btn_jackpot;
    public GameObject jackpot_back;
    private Text txt;
    private GameObject liquid;
    private Animator anim;
    public Sprite jackpot;
    public Sprite jackpot100;
    private WebGLSendContractExample sendContract;
    public float bottom;
    private float top;
    private float rand;
    private float offset;
    private float score;
    private int timer;
    private int flag;

    [DllImport("__Internal")]
    private static extern void Reload();

    public void SetBottom(string bet)
    {
        if(bet == "5"){
            bottom = -0.42f;
        } else if(bet == "10"){
            bottom = -0.3f;
        } else if(bet == "20"){
            bottom = -0.12f;
        } else if(bet == "50"){
            bottom = 0.11f;
        } else {
            bottom = -0.59f;
        }
    }

    void Start()
    {
        Button btn = btn_pee.GetComponent<Button>();
        btn.onClick.AddListener(AnimGoToPee);
        timer = 0;
        flag = 0;
        bottom = -0.59f;
        top = 0.29f;
    }

    // Update is called once per frame
    void Update()
    {
        if(flag == 1){
            timer ++;
            if(timer > 80 && timer < 150){
               obj_liquid.transform.Translate(0, 0, -offset); 
            }
            else if(timer > 150){
                flag = 0;
                btn_bet.SetActive(true);
                btn_pee_obj.SetActive(true);
                score = (rand + 0.59f) * 100 / 0.88f;
                replay_panel.SetActive(true);
                Button replay = btn_replay.GetComponent<Button>();
                replay.onClick.AddListener(OnReplay);
                txt = GameObject.Find("score-text").GetComponentInChildren<Text>();
                score = (int)score;
                if(score > 70){
                    btn_jackpot.GetComponent<Image>().sprite = jackpot100;
                    jackpot_back.SetActive(true);
                    Button btn = btn_jackpot100.GetComponent<Button>();
                    btn.onClick.AddListener(sendContract.OnSendContractForReward);
                    // sendContract.OnSendContractForReward();
                }
                txt.text = "Your Score: " + score.ToString();
                
            }
        }        
    }
    
    void AnimGoToPee()
    {
        btn_pee_obj.SetActive(false);
        rand = Random.Range(bottom, top);
        offset = (rand+0.59f)/70f;
        flag = 1;
        anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("Active");
    }

    void OnReplay()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("Init");
        timer = 0;
        flag = 0;
        bottom = -0.59f;
        top = 0.29f;
        replay_panel.SetActive(false);
        obj_liquid.transform.position = new Vector3(0.803f, -0.586f, 0.371f);
        
    }
    
    
}
