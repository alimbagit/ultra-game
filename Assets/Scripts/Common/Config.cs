using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Config : MonoBehaviour
{
    public class OneAxis
    {
        public OneAxis(string name_key, string positive_key)
        {
            name = name_key;
            positive = positive_key;
        }
        public OneAxis(string name_key, string positive_key,string negative_key)
        {
            name = name_key;
            positive = positive_key;
            negative = negative_key;
        }
        public string positive;
        public string negative;
        public string name;
    }
    public struct Axes
    {
        public OneAxis horizontal;
        public OneAxis vertical;

        public OneAxis[] abilities;
        public OneAxis to_config;
        public OneAxis reload_weapon;
        public OneAxis fire1;
        public OneAxis fire2;
        public OneAxis jump;
    }

    public Axes axes;

    void Awake()
    {
        axes.horizontal=new OneAxis("Horizontal","d","a");
        axes.vertical = new OneAxis( "Vertical","w","s");
        axes.abilities = new OneAxis[6];
        axes.abilities[0] = new OneAxis("Ability1", "q");
        axes.abilities[1] = new OneAxis("Ability2", "e");
        axes.abilities[2] = new OneAxis("Ability3", "x");
        axes.abilities[3] = new OneAxis("Ability4", "c");
        axes.abilities[4]= new OneAxis("Ability5", "v");
        axes.abilities[5] = new OneAxis("Ability6", "shift");
        axes.to_config = new OneAxis("To config","b");
        axes.reload_weapon = new OneAxis("Reload weapon","r");
        axes.fire1 = new OneAxis( "Fire1","mouse 0");
        axes.fire2 = new OneAxis( "Fire2","mouse 1");
        axes.jump = new OneAxis( "Jump","space");
    }

    void Update()
    {
        
    }
}
