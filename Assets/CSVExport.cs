using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Globalization;
using System.Diagnostics;

public class CSVExport : MonoBehaviour
{
    string filename = "";
    [System.Serializable]
    public class Player {
        public string Name;
        public string PhoneNo;
        public string Email;
        public DateTime DateTime;
    }

    [System.Serializable]
    public class PlayerList {
        public Player[] player;
    }

    public PlayerList myPlayerList = new PlayerList();

    // Start is called before the first frame update
    void Start()
    {
        filename = Application.dataPath + "/test.csv";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            WriteCSV();
            System.Diagnostics.Debug.WriteLine("Pressed");
        }
    }

    public void WriteCSV() {
        if(myPlayerList.player.Length > 0) {
            // This line overwrites an existing file (false -> overwrites,  true-> NO overwrite)

            TextWriter tw = new StreamWriter(filename, false);

            tw.WriteLine("Name, PhoneNo, Email, DateTime");
            tw.Close();

            tw = new StreamWriter(filename, true);


            for (int i = 0; i < myPlayerList.player.Length; i++) {
                var thisplayer = myPlayerList.player[i];
                tw.WriteLine($@"{thisplayer.Name} , {thisplayer.PhoneNo} , {thisplayer.Email} , {DateTime.Now}");
            }
            tw.Close();
        }
        
    }
}
