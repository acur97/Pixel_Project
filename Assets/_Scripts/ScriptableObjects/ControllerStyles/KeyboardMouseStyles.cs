using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(KeyboardMouseStyles))]
class KeyboardMouseStylesEditor : Editor
{
    KeyboardMouseStyles component;
    Sprite sprite;

    private void OnEnable()
    {
        component = (KeyboardMouseStyles)target;
        EditorUtility.SetDirty(component);
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("Key Blanks", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.enter, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.enter)
            {
                component.enter = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("enter");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.normal, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.normal)
            {
                component.normal = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("normal");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.superWide, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.superWide)
            {
                component.superWide = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("superWide");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.tall, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.tall)
            {
                component.tall = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("tall");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.wide, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.wide)
            {
                component.wide = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("wide");
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Mouse", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.mouse, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.mouse)
            {
                component.mouse = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("mouse");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.mouseLeft, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.mouseLeft)
            {
                component.mouseLeft = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("mouseLeft");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.mouseMiddle, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.mouseMiddle)
            {
                component.mouseMiddle = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("mouseMiddle");
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        {
            sprite = EditorGUILayout.ObjectField(component.mouseRight, typeof(Sprite), false, GUILayout.Height(50), GUILayout.Width(50)) as Sprite;
            if (sprite != component.mouseRight)
            {
                component.mouseRight = sprite;
                EditorUtility.SetDirty(component);
            }
            EditorGUILayout.LabelField("mouseRight");
        }
        EditorGUILayout.EndHorizontal();
    }
}
#endif

[CreateAssetMenu(fileName = "KeyboardMouse", menuName = "Scriptable Objects/Controller Styles/Keyboard Mouse", order = 3)]
public class KeyboardMouseStyles : ScriptableObject
{
    [Header("Key Blanks")]
    public Sprite enter;
    public Sprite normal;
    public Sprite superWide;
    public Sprite tall;
    public Sprite wide;

    [Header("Mouse")]
    public Sprite mouse;
    public Sprite mouseLeft;
    public Sprite mouseMiddle;
    public Sprite mouseRight;
}