using UnityEngine;
using System.Collections;

public class ButtonLamp : MonoBehaviour
{
    protected bool onoff = false;
    [SerializeField] GameObject Lamp;
    public bool islocked = false;
    int i1 = 0, i3=0;
    [SerializeField]LayerMask buttonLayer;
    
    public IEnumerator GetEnumerator()
    {
        switch (islocked)
        {

            case true:
                while (i1 < 10)
                {
                    //print("0");
                    Lamp.transform.Translate(Vector2.down * 0.5f);
                    i1++;
                    yield return new WaitForSeconds(0.3f);
                }
                //islocked = false;
                break;
            case false:
                while (i1 >= 1)
                {
                    //print("1");
                    Lamp.transform.Translate(Vector2.up * 0.5f);
                    i1--;
                    yield return new WaitForSeconds(0.3f);
                }
                //islocked = true;
                break;
        }
    }
    public void UpdDownWall()
    {
        Lamp.transform.Translate(Vector2.down * 2);
    }
    public void ButtonOnOff(bool value)
    {
        onoff = value;
    }
    Vector3 tStartPos1;
    // Use this for initialization
    void Start()
    {
        tStartPos1 = Lamp.transform.position;
        GameMode.THIS.AddButtonLamps(this);
    }
    protected int tick = 0;
    // Update is called once per frame
    void Update()
    {
        if (Lamp.transform.Find("lampOn")) Lamp.transform.Find("lampOn").gameObject.SetActive(onoff);
        RaycastHit2D rayButton = MMDebug.RayCast(transform.position, Vector2.up, 1.5f, buttonLayer, Color.blue, true);
        if (rayButton) { if (tick == 0) { islocked = !islocked; } tick += 1;  }
        else if (!rayButton) { tick = 0; }

    }
    
}
