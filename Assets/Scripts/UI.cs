using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class player_Info {

    public player_Info() {
        Player_ID = 0;
        Color = new Color(0,0,0);
        Skill = 1;
    }

    private int _player_ID;
    public int Player_ID
    {
        get
        {
            return _player_ID;
        }

        set
        {
            _player_ID = value;
        }
    }

    private Color _color;
    public Color Color
    {
        get
        {
            return _color;
        }

        set
        {
            _color = value;
        }
    }

    private int _skill;
    public int Skill
    {
        get
        {
            return _skill;
        }

        set
        {
            _skill = value;
        }
    }

}

public class UI : MonoBehaviour {

    player_Info data;
    public Texture[] skill = new Texture[5];
    Slider r, g, b;
    RawImage skill_image,character;
    private void Start()
    {
        data = new player_Info();
        string name = this.transform.GetChild(0).GetComponent<Text>().text;
        char[] ID = name.Substring(name.Length - 1).ToCharArray();
        data.Player_ID = ID[0] - 48;
        character = this.transform.GetChild(1).GetComponentInChildren<RawImage>();
        r = this.transform.GetChild(1).GetChild(1).GetComponent<Slider>();
        g = this.transform.GetChild(1).GetChild(2).GetComponent<Slider>();
        b = this.transform.GetChild(1).GetChild(3).GetComponent<Slider>();
        //Debug.Log(name);
        //Debug.Log(data.Player_ID);
        //Debug.Log(this.transform.GetChild(2).gameObject.name);
        skill_image = this.transform.GetChild(2).GetComponentInChildren<RawImage>();
        skill_image.texture = skill[data.Skill];
    }
    private void update_color() {
        character.color = data.Color;
    }
    public void character_R() {
        data.Color = new Color(r.value, data.Color.g, data.Color.b);
        r.transform.GetChild(0).GetComponent<Image>().color = new Color(r.value, 0, 0);
        r.transform.GetChild(1).GetComponentInChildren<Image>().color = new Color(r.value, 0, 0);
        update_color();
    }
    public void character_G() {
        data.Color = new Color(data.Color.r, g.value, data.Color.b);
        g.transform.GetChild(0).GetComponent<Image>().color = new Color(0, g.value, 0);
        g.transform.GetChild(1).GetComponentInChildren<Image>().color = new Color(0, g.value, 0);
        update_color();
    }
    public void character_B() {
        data.Color = new Color(data.Color.r, data.Color.g, b.value);
        b.transform.GetChild(0).GetComponent<Image>().color = new Color(0, 0, b.value);
        b.transform.GetChild(1).GetComponentInChildren<Image>().color = new Color(0, 0, b.value);
        update_color();
    }
    public void skill_right()
    {
        data.Skill++;
        if (data.Skill > 5)
            data.Skill = 1;
        skill_image.texture = skill[data.Skill-1];
    }
    public void skill_left()
    {
        data.Skill--;
        if (data.Skill < 1)
            data.Skill = 5;
        skill_image.texture = skill[data.Skill-1];
    }

}
