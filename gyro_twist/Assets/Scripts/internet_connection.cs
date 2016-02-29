using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System;
using System.Text;

public class internet_connection : MonoBehaviour {

    private string url = "https://dl.dropboxusercontent.com/u/12725910/scores.txt";

    public Text scores;
    

    private StreamWriter writer; // This is the writer that writes to the file

    void Start () {

        scores.text = "Conectando...";
        StartCoroutine(GetScores());
    }

    private IEnumerator GetScores()
    {
        WWW file = new WWW(url);

        yield return file;


        if (file.error != null)
        {
            //Debug.Log("Error .. " + file.error);
            scores.text = "Erro: Falha de conexão!";
            // for example, often 'Error .. 404 Not Found'
        }
        else
        {
            Debug.Log(file.text);
            scores.text = file.text;
        }


        

        Encoding utf8 = Encoding.UTF8;
        Encoding ascii = Encoding.ASCII;

        byte[] bytesToEncode = Encoding.UTF8.GetBytes(file.text);
        string encodedText = Convert.ToBase64String(bytesToEncode);

        byte[] decodedBytes = Convert.FromBase64String(encodedText);
        string decodedText = Encoding.UTF8.GetString(decodedBytes);

        //Debug.Log(decodedText);

        // returned from www.bytes, copied here for readability
        byte[] bytes = new byte[] { 116, 101, 120, 116, 105, 110, 101, 115, 115 };
        byte[] utf8bytes = utf8.GetBytes(file.text);
        byte[] asciibytes = ascii.GetBytes(file.text);

        string customDecoded = "";
        foreach (var b in file.bytes)
            customDecoded += (char)b;

        //Debug.Log(customDecoded); // textiness
        //Debug.Log(System.Text.Encoding.Default); // System.Text.ASCIIEncoding

        //Debug.Log(System.Text.Encoding.Default.GetString(utf8bytes));  // textiness
        //Debug.Log(System.Text.Encoding.Default.GetString(utf8bytes));  // textiness
        //Debug.Log(System.Text.Encoding.ASCII.GetString(utf8bytes));  // textiness
        //Debug.Log(System.Text.Encoding.Unicode.GetString(utf8bytes)); // 整瑸湩獥
        //Debug.Log(System.Text.Encoding.UTF7.GetString(utf8bytes)); // textiness
        //Debug.Log(System.Text.Encoding.UTF8.GetString(utf8bytes)); // textiness
        //Debug.Log(System.Text.Encoding.UTF32.GetString(utf8bytes)); // 整湩
        //Debug.Log(System.Text.Encoding.BigEndianUnicode.GetString(utf8bytes)); // 瑥硴楮敳




    }

    private bool Load(string fileName)
    {
        // Handle any problems that might arise when reading the text
        try
        {
            string line;
            // Create a new StreamReader, tell it which file to read and what encoding the file
            // was saved as
            StreamReader theReader = new StreamReader(fileName, Encoding.ASCII);
            // Immediately clean up the reader after this block of code is done.
            // You generally use the "using" statement for potentially memory-intensive objects
            // instead of relying on garbage collection.
            // (Do not confuse this with the using directive for namespace at the 
            // beginning of a class!)
            using (theReader)
            {
                // While there's lines left in the text file, do this:
                do
                {
                    line = theReader.ReadLine();

                    Debug.Log(line);

                    if (line != null)
                    {
                        // Do whatever you need to do with the text line, it's a string now
                        // In this example, I split it into arguments based on comma
                        // deliniators, then send that array to DoStuff()
                        string[] entries = line.Split(',');
                        if (entries.Length > 0)
                        {
                            Debug.Log("teste");
                        }
                            
                    }
                }
                while (line != null);
                // Done reading, close the reader and return true to broadcast success    
                theReader.Close();
                return true;
            }
        }
        // If anything broke in the try block, we throw an exception with information
        // on what didn't work
        catch (Exception e)
        {
            Console.WriteLine("{0}\n", e.Message);
            return false;
        }
    }

    void readTextFile(string file_path)
    {
        StreamReader inp_stm = new StreamReader(file_path);

        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            // Do Something with the input. 
        }

        inp_stm.Close();
    }
}

