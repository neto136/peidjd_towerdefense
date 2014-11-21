using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class TileMap : MonoBehaviour {

	int[][] generateMap(string filename) {
		FileInfo source = new FileInfo (filename);
		StreamReader reader = source.OpenText ();

		// Conta numero de linha do arquivo.
		// Sera a altura da matriz map.
		int file_length = fileLineCount(filename);

		string line = reader.ReadLine();
		// Largura de uma linha do arquivo.
		// Sera largura da matriz map.
		int file_width = line.Split(" ").Length;

		int[,] map = new int[file_width, file_length];
		int i = 0;

		string[] split = line.Split(' ');
		for (int j = 0; j < split.Length; j++) 
			map[i,j] = split[j];
		

		do {
			// Recupera linha do arquivo
			line = reader.ReadLine();
			split = line.Split(' ');

			for (int j = 0; j < split.Length; j++)
				map[i,j] = split[j];

			i++;
		} while(line != null);
	}

	int fileLineCount(string filename) {
		int lineCount = 0;
		using (var reader = File.OpenText(filename))
		{
			while (reader.ReadLine() != null)
			{
				lineCount++;
			}
		}
		return lineCount; 
	}

	// Use this for initialization
	void Start () {
		FileInfo source = new FileInfo ("level_test.lev");
		StreamReader reader = source.OpenText ();

		string text;

		do {
			text = reader.ReadLine();
			print (text);
		} while(text != null);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
