﻿using UnityEngine;
using System.Collections;
using System.IO;

public class GuardarDatos : MonoBehaviour {
	public GameObject correcta;
	// Use this for initialization
	public string ruta;
	public string  texto="";

	void Start(){
		ruta = Application.persistentDataPath;
		ruta += "/Resources/Fase5/";
		Directory.CreateDirectory (ruta);
		ruta += "Evaluacion.txt";
		if (File.Exists (ruta) == false) {
			File.Create (ruta);
		}

	}

	public void GuardaValores() {
		File.WriteAllText(ruta,texto);
	//	File.WriteAllText ("Evaluacion.txt", texto);

	}
}