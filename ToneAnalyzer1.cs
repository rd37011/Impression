using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using IBM.Watson.DeveloperCloud.Services.ToneAnalyzer.v3;
using UnityEngine.UI;


public class ToneAnalyzer1 : MonoBehaviour
{
    public InputField mainInputField;
    ToneAnalyzer m_ToneAnalyzer = new ToneAnalyzer();
    string m_StringToTestTone;
    
        
    void Start()
    { 
		m_StringToTestTone = "HIS glory, by whose might all things are moved,\t\nPierces the universe, and in one part\t\nSheds more resplendence, elsewhere less. In\t\nThat largeliest of His light partakes, was I, [Heaven\t\nWitness of things, which, to relate again,\t        5\nSurpasseth power of him who comes from thence;\t\nFor that, so near approaching its desire,\t\nOut intellect is to such depth absorb’d,\t\nThat memory cannot follow. Nathless all,\t\nThat in my thoughts I of that sacred realm\t        10\nCould store, shall now be matter of my song.\t\n  Benign Apollo! this last labour aid;\t\nAnd make me such a vessel of thy worth,\t\nAs thy own laurel claims, of me beloved.";
        m_ToneAnalyzer.GetToneAnalyze(OnGetToneAnalyze, m_StringToTestTone);
    }
    Texture2D mytexture;
    string funct;
   
    private void OnGetToneAnalyze(ToneAnalyzerResponse resp, string data)
    {
        Debug.Log(resp);
        string response = resp.ToString();
        response.ToCharArray();
        double[] arr = new double[5];
        int i = 0;
        string sub;
        for (int j = 0; j < 5; j++)
        {
            while (response[i] != '0')
            {
                i++;
            }
            sub = response.Substring(i, 5);
            i = i + 11;
            Debug.Log(sub);
            arr[j] = Convert.ToDouble(sub);
        }
        int max = 0;
        for (int k = 1; k < 5; k++)
        {
            if (arr[k] > arr[max]) max = k;
        }


        string result = "";
        if (max == 0)
        {
            result = "anger";
            funct = result;
        }
        else if (max == 1)
        {
            result = "disgust";
            funct = result;
        }
        else if (max == 2)
        {
            result = "fear";
            funct = result;
        }
        else if (max == 3)
        {
            result = "joy";
            funct = result;
        }
        else if (max == 4)
        {
            result = "sadness";
            funct = result;
        }
        Debug.Log(result);

    }

    void OnGUI()
    {
        mytexture = Resources.Load(funct) as Texture2D;
        GUI.DrawTexture(new Rect(100, 0, 500, 500), mytexture);
    }
}