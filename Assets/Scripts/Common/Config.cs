using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Config : MonoBehaviour
{
    public struct Axes
    {
        public string horizontal;
        public string vertical;

        public string[] abilities;
        //public string ability1;
        //public string ability2;
        //public string ability3;
        //public string ability4;
        //public string ability5;
        //public string ability6;
        public string to_config;
        public string reload_weapon;
        public string fire1;
        public string fire2;
        public string jump;
    }

    public Axes axes;


    public static void ReadAxes()
    {
        var inputManager = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0];

        SerializedObject obj = new SerializedObject(inputManager);

        SerializedProperty axisArray = obj.FindProperty("m_Axes");

        if (axisArray.arraySize == 0)
            Debug.Log("No Axes");

        for (int i = 0; i < axisArray.arraySize; ++i)
        {
            var axis = axisArray.GetArrayElementAtIndex(i);

            var name = axis.FindPropertyRelative("m_Name").stringValue;
            var axisVal = axis.FindPropertyRelative("axis").intValue;
            var inputType = (InputType)axis.FindPropertyRelative("type").intValue;

            Debug.Log(name);
            Debug.Log(axisVal);
            Debug.Log(inputType);
        }
    }

    public enum InputType
    {
        KeyOrMouseButton,
        MouseMovement,
        JoystickAxis,
    };

    [MenuItem("Assets/ReadInputManager")]
    public static void DoRead()
    {
        ReadAxes();
    }

    void Awake()
    {
        DoRead();
        axes.horizontal = "Horizontal";
        axes.vertical = "Vertical";
        axes.abilities = new string[6];
        axes.abilities[0] = "Ability1";
        axes.abilities[1] = "Ability2";
        axes.abilities[2] = "Ability3";
        axes.abilities[3] = "Ability4";
        axes.abilities[4] = "Ability5";
        axes.abilities[5] = "Ability6";
        axes.to_config = "To config";
        axes.reload_weapon = "Reload weapon";
        axes.fire1 = "Fire1";
        axes.fire2 = "Fire2";
        axes.jump = "Jump";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
