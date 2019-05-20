using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Script.SaveLoad
{
    public static class InputManager
    {
        #if UNITY_EDITOR
        private static Dictionary<string, string> convert = new Dictionary<string, string>
        {
            {"RightShift", "right shift"},
            {"LeftShift", "left shift"},
            {"RightControl", "right ctrl"},
            {"LeftControl", "left ctrl"},
            {"RightAlt", "right alt"},
            {"LeftAlt", "left alt"},
            {"Space", "space"},
            {"Q", "q"},
            {"E", "e"},
            {"R", "r"},
            {"T", "t"},
            {"Y", "y"},
            {"U", "u"},
            {"I", "i"},
            {"O", "o"},
            {"P", "p"},
            {"F", "f"},
            {"G", "g"},
            {"H", "h"},
            {"J", "j"},
            {"K", "k"},
            {"L", "l"},
            {"Z", "z"},
            {"X", "x"},
            {"C", "c"},
            {"V", "v"},
            {"B", "b"},
            {"N", "n"},
            {"M", "m"}
        };
        
        public static void SetButton(string axisName, string value)
        {
            value = convert.ContainsKey(value) ? convert[value] : convert.ContainsValue(value) ? value : string.Empty;
            if (string.IsNullOrEmpty(value)) return;
            SerializedObject serializedObject = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0]);
            SerializedProperty axesProperty = serializedObject.FindProperty("m_Axes");
            SerializedProperty axis = FindAxis(axesProperty, axisName);
            if (axis == null) return;
            GetChildProperty(axis, "positiveButton").stringValue = value;
            serializedObject.ApplyModifiedProperties();
        }

        public static string GetValue(string axisName)
        {
            SerializedObject serializedObject = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0]);
            SerializedProperty axesProperty = serializedObject.FindProperty("m_Axes");
            SerializedProperty axis = FindAxis(axesProperty, axisName);
            return axis == null ? "" : GetChildProperty(axis, "positiveButton").stringValue;
        }
        
        public static int ConvertToInt(string code)
        {
            string s = convert.FirstOrDefault(x => x.Value.Equals(code)).Key;
            if (Enum.TryParse<KeyCode>(s, out var c)) return (int) c;
            return -1;
        }

        public static string ConvertToCode(int value)
        {
            return ConvertToCode(((KeyCode) value).ToString());
        }

        public static string ConvertToCode(string value)
        {
            return convert.ContainsKey(value) ? convert[value] : "";
        }

        private static SerializedProperty FindAxis(SerializedProperty axes, string axisName)
        {
            if (!AxisDefined(axisName)) return null;
            return FindInArray(axes, axisName);
        }
        
        private static bool AxisDefined(string axisName)
        {
            SerializedObject serializedObject = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0]);
            SerializedProperty axesProperty = serializedObject.FindProperty("m_Axes");

            axesProperty.Next(true);
            axesProperty.Next(true);
            while (axesProperty.Next(false))
            {
                SerializedProperty axis = axesProperty.Copy();
                axis.Next(true);
                if (axis.stringValue == axisName) return true;
            }
            return false;
        }
            
        private static SerializedProperty GetChildProperty(SerializedProperty parent, string name)
        {
            SerializedProperty child = parent.Copy();
            child.Next(true);
            do
            {
                if (child.name == name) return child;
            }
            while (child.Next(false));
            return null;
        }

        private static SerializedProperty FindInArray(SerializedProperty parent, string name)
        {
            for (int i = 0; i < parent.arraySize; i++)
            {
                SerializedProperty prop = parent.GetArrayElementAtIndex(i);
                string v = GetChildProperty(prop, "m_Name").stringValue;
                if (v == name) return prop;
            }
            return null;
        }

        private static bool FindWithSameValue(SerializedProperty parent, string value)
        {
            for (int i = 0; i < parent.arraySize; i++)
            {
                SerializedProperty prop = parent.GetArrayElementAtIndex(i);
                string v = GetChildProperty(prop, "positiveButton").stringValue;
                if (v == value) return true;
            }
            return false;
        }
        #endif
    }
}