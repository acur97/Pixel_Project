using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(GamepadStyles))]
class GamepadStylesEditor : Editor
{
    GamepadStyles component;
    Sprite sprite;

    private void OnEnable()
    {
        component = (GamepadStyles)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("Sticks", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.leftStick, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.leftStick)
            {
                component.leftStick = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("leftStick");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.rightStick, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.rightStick)
            {
                component.rightStick = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("rightStick");
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Dpad", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.dpad, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.dpad)
            {
                component.dpad = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("dpad");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.dpad_up, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.dpad_up)
            {
                component.dpad_up = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("dpad_up");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.dpad_down, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.dpad_down)
            {
                component.dpad_down = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("dpad_down");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.dpad_left, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.dpad_left)
            {
                component.dpad_left = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("dpad_left");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.dpad_right, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.dpad_right)
            {
                component.dpad_right = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("dpad_right");
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Buttons", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.buttonNorth, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.buttonNorth)
            {
                component.buttonNorth = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("buttonNorth");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.buttonSouth, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.buttonSouth)
            {
                component.buttonSouth = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("buttonSouth");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.buttonWest, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.buttonWest)
            {
                component.buttonWest = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("buttonWest");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.buttonEast, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.buttonEast)
            {
                component.buttonEast = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("buttonEast");
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.leftShoulder, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.leftShoulder)
            {
                component.leftShoulder = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("leftShoulder");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.rightShoulder, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.rightShoulder)
            {
                component.rightShoulder = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("rightShoulder");
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.leftTrigger, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.leftTrigger)
            {
                component.leftTrigger = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("leftTrigger");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.rightTrigger, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.rightTrigger)
            {
                component.rightTrigger = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("rightTrigger");
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.startButton, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.startButton)
            {
                component.startButton = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("startButton");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.selectButton, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.selectButton)
            {
                component.selectButton = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("selectButton");
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.leftStickButton, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.leftStickButton)
            {
                component.leftStickButton = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("leftStickButton");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.rightStickButton, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.rightStickButton)
            {
                component.rightStickButton = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("rightStickButton");
        }
        EditorGUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
    }
}
#endif

[CreateAssetMenu(fileName = "Gamepad", menuName = "Scriptable Objects/Controller Styles/Gamepad", order = 0)]
public class GamepadStyles : ScriptableObject
{
    [Header("Sticks")]
    public Sprite leftStick;
    public Sprite rightStick;

    [Header("Dpad")]
    public Sprite dpad;
    public Sprite dpad_up;
    public Sprite dpad_down;
    public Sprite dpad_left;
    public Sprite dpad_right;

    [Header("Buttons")]
    public Sprite buttonNorth;
    public Sprite buttonSouth;
    public Sprite buttonWest;
    public Sprite buttonEast;
    [Space]
    public Sprite leftShoulder;
    public Sprite rightShoulder;
    [Space]
    public Sprite leftTrigger;
    public Sprite rightTrigger;
    [Space]
    public Sprite startButton;
    public Sprite selectButton;
    [Space]
    public Sprite leftStickButton;
    public Sprite rightStickButton;
}