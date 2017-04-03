using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlanetBase))]
public class PlanetEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        PlanetBase myTarget = (PlanetBase)target;

        GUIStyle bold = GUI.skin.GetStyle("Label");
        bold.fontStyle = FontStyle.Bold;
        //Atmosphere
        EditorGUILayout.BeginVertical("button");
        EditorGUILayout.LabelField("Atmosphere", bold);
        myTarget.hasWater = EditorGUILayout.Toggle(new GUIContent ("Water?", "Is there water on the planet?"), myTarget.hasWater);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(new GUIContent ("Low Temperature(c°)", "What is the lowest temperature?"));
        EditorGUILayout.LabelField(new GUIContent ("High Temperature(c°)", "What is the highest temperature?"));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        myTarget.lowTemp = EditorGUILayout.FloatField(myTarget.lowTemp);
        myTarget.highTemp = EditorGUILayout.FloatField(myTarget.highTemp);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.MinMaxSlider(ref myTarget.lowTemp, ref myTarget.highTemp, -100, 100);
        myTarget.radiationAmount = EditorGUILayout.FloatField(new GUIContent ("Radiation(rad)" , "How much radiation?"), myTarget.radiationAmount);
        EditorGUILayout.EndVertical();

        //Life
        EditorGUILayout.BeginVertical("button");
        EditorGUILayout.LabelField("Life", bold);
        myTarget.isHabitable = EditorGUILayout.BeginToggleGroup("Is Habitable",myTarget.isHabitable);
        EditorGUILayout.BeginHorizontal();
        if(myTarget.isHabitable)
            myTarget.flora = EditorGUILayout.BeginToggleGroup(new GUIContent ("Flora", "Plant Life"), myTarget.flora);
        else
            myTarget.flora = EditorGUILayout.BeginToggleGroup(new GUIContent("Flora", "Must Be Habitable"), myTarget.flora);
        if (myTarget.flora)
            myTarget.fauna = EditorGUILayout.Toggle(new GUIContent("Fauna", "Animal Life"), myTarget.flora);
        else
            myTarget.fauna = EditorGUILayout.Toggle(new GUIContent("Fauna", "Must Have Flora"), myTarget.flora);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndToggleGroup();
        EditorGUILayout.EndToggleGroup();
        EditorGUILayout.BeginHorizontal();
        myTarget.intelligentCreatures = EditorGUILayout.BeginToggleGroup(new GUIContent ("Intelligent Creatures", "Are There Intelligent Creatures?"), myTarget.intelligentCreatures);
        myTarget.icPopulation = EditorGUILayout.IntField(myTarget.icPopulation);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndToggleGroup();
        EditorGUILayout.EndVertical();


        //Surface
        EditorGUILayout.BeginVertical("button");
        EditorGUILayout.LabelField("Surface", bold);
        myTarget.mainColor = EditorGUILayout.ColorField("Planet Color", myTarget.mainColor);
        myTarget.planetSize = EditorGUILayout.IntField(new GUIContent("Planet Size", "The Earth is about 3919"), myTarget.planetSize);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(new GUIContent("Low Elevation", "Lowest the planet can be"));
        EditorGUILayout.LabelField(new GUIContent("High Elevation", "Highest the planet can be"));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        myTarget.lowElevation = EditorGUILayout.FloatField(myTarget.lowElevation);
        myTarget.highElevation = EditorGUILayout.FloatField(myTarget.highElevation);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.MinMaxSlider(ref myTarget.lowElevation, ref myTarget.highElevation, -100, 100);
        EditorGUILayout.EndVertical();


        //Orbit & Time
        EditorGUILayout.BeginVertical("button");
        EditorGUILayout.LabelField("Orbit & Time", bold);
        myTarget.moonAmount = EditorGUILayout.IntField("Number of Moons", myTarget.moonAmount);
        GUIStyle myStyle = GUI.skin.GetStyle("Label");
        EditorGUILayout.LabelField("");
        myStyle.alignment = TextAnchor.MiddleCenter;
        myStyle.fontStyle = FontStyle.Bold;
        EditorGUILayout.LabelField("Time",myStyle);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(new GUIContent("Revolution", "Hours in a day"));
        EditorGUILayout.LabelField(new GUIContent("Orbit", "Days it takes to make a full orbit"));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        myTarget.revolutionTime = EditorGUILayout.FloatField(myTarget.revolutionTime);
        myTarget.orbitTime = EditorGUILayout.FloatField(myTarget.orbitTime);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("button");
        serializedObject.Update();
        SerializedProperty myElem = serializedObject.FindProperty("mainElements");
        EditorGUILayout.PropertyField(myElem, true);
        serializedObject.ApplyModifiedProperties();
        //Main Elements
        /*
        EditorGUILayout.BeginVertical("button");
        EditorGUILayout.LabelField("Elements", bold);
        EditorGUILayout.IntField("Size", myTarget.mainElements.GetLength(0));
        int elements = myTarget.mainElements.GetLength(0);
        for(int count = 0; count < elements; count++)
        {
            myTarget.mainElements[count] = EditorGUILayout.TextField("Element " + count.ToString(), myTarget.mainElements[count]);
        }
        */
        EditorGUILayout.EndVertical();
    }
}

//Atmosphere: hasWater, highTemp, lowTemp, radiationAmount
//Life: isHabitable, flora, fauna, intelligentCreatures icPopulation
//Surface: mainColor, planetSize, lowElevation, highElevation
//Orbit & Time: revolutionTime, orbitTime, moonAmount
//Main Elements: mainElements