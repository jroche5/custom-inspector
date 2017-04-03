using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBase : MonoBehaviour {
    public Color mainColor; //used to color the planetDONE
    public bool hasWater; //does it have water?DONE
    public float highTemp, lowTemp; //range of tempDONE
    public float revolutionTime; //How many hours a day cycle takesDONE
    public bool fauna; //Does it have fauna, only works if the planet has flora;DONE
    public int moonAmount; //does it have moons? How many;DONE
    public float orbitTime; //How many planet days does it take to oribit (planet year)DONE
    public bool isHabitable; //does it support natural life?DONE
    public float lowElevation;// Lowest elevationDONE
    public bool flora; //does the planet have plant life, only works if it isHa;DONE
    public int planetSize; //radius of planet, measured in milesDONE
    public float radiationAmount; // measured in radsDONE
    public bool intelligentCreatures; //does it have intelligent creatures, native or otherwise;DONE
    public float highElevation;//Highest elevation;DONE
    public int icPopulation; //if it has intel creatures, how many;DONE
    public string[] mainElements; // What elements it hosts;SET


    private GameObject[] theMoons;//used to 
	// Use this for initialization
	void Start () {
        float smallerSize = planetSize/100;
        transform.localScale = new Vector3(smallerSize, smallerSize, smallerSize);
        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
        Material myMaterial = new Material(renderer.material) ;
        mainColor.a = 1f;
        myMaterial.color = mainColor;
        renderer.material = myMaterial;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

//Atmosphere: hasWater, highTemp, lowTemp, radiationAmount
//Life: isHabitable, flora, fauna, intelligentCreatures icPopulation
//Surface: lowElevation, highElevation, planetSize, mainColor
//Orbit & Time: revolutionTime, orbitTime, moonAmount
//Main Elements: mainElements