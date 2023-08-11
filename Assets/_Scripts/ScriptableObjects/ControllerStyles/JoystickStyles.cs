using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(JoystickStyles))]
class JoystickStylesEditor : Editor
{
    JoystickStyles component;
    Sprite sprite;

    private void OnEnable()
    {
        component = (JoystickStyles)target;
        EditorUtility.SetDirty(component);
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("Stick", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.stick, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.stick)
            {
                component.stick = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("stick");
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Hatswitch", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.hat, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.hat)
            {
                component.hat = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("hat");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.hat_up, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.hat_up)
            {
                component.hat_up = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("hat_up");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.hat_down, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.hat_down)
            {
                component.hat_down = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("hat_down");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.hat_left, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.hat_left)
            {
                component.hat_left = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("hat_left");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.hat_right, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.hat_right)
            {
                component.hat_right = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("hat_right");
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Buttons", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.trigger, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.trigger)
            {
                component.trigger = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("trigger");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.button, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.button)
            {
                component.button = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("button");
        }
        EditorGUILayout.EndHorizontal();
    }
}
#endif

[CreateAssetMenu(fileName = "Joystick", menuName = "Scriptable Objects/Controller Styles/Joystick", order = 1)]
public class JoystickStyles : ScriptableObject
{
    [Header("Stick")]
    public Sprite stick;

    [Header("Hatswitch")]
    public Sprite hat;
    public Sprite hat_up;
    public Sprite hat_down;
    public Sprite hat_left;
    public Sprite hat_right;

    [Header("Buttons")]
    public Sprite trigger;
    public Sprite button;
}