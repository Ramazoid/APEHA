using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesManager : MonoBehaviour
{

    public Text WaveTitle;
    public int VaweNumber=0;
    public LineHelper VaweEmitterStart;
    public int bornCycleFrameRate = 30;
    [Header("Born Cycles between waves")]
    public int FramesBetweenWaves = 300;
    public List<Wave> waves;
    public int bornFrame;
    public  int wavepause;
    private TowerDriver driver;
    private bool gameover;
    private UIPUlseManager pulseManager;
    private Utilizer utilizer;

    void Start()
    {
        bornFrame = bornCycleFrameRate;
        wavepause  = FramesBetweenWaves;
        driver = FindObjectOfType<TowerDriver>();
        pulseManager = GetComponent<UIPUlseManager>();pulseManager.Init();
        pulseManager.GoIn("HandTip", null);
        pulseManager.GoIn("WaveNumber", "Wave" + (VaweNumber + 1).ToString());
        utilizer = GetComponent<Utilizer>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if(--bornFrame<=0&& !gameover)
        {
            bornFrame = bornCycleFrameRate;
            if(--wavepause<=0)
            BornRabbit();
            if(wavepause>=0)
                pulseManager.Redraw("WaveNumber", "Wave " + (VaweNumber + 1) + " (" + wavepause + ")");
            else
                pulseManager.Redraw("WaveNumber", "Wave " + (VaweNumber + 1) + " GO!");
        }
        
            
        
    }

    private void BornRabbit()
    {
        Wave w = waves[VaweNumber];
        Vector3 pos = VaweEmitterStart.transform.position - VaweEmitterStart.EndPointObject.position;
        Vector3 rabbitPos = VaweEmitterStart.transform.position - pos * UnityEngine.Random.insideUnitCircle.magnitude;
        //driver.SETTurrelElevation(rabbitPos.y - 1);

        GameObject rabbit = utilizer.GetRabbit(w.wave[w.index].name);
        if (rabbit == null)
            rabbit = Instantiate(w.wave[w.index], rabbitPos, Quaternion.identity);
        rabbit.SetActive(true);
        rabbit.transform.position = rabbitPos;
        rabbit.name = w.wave[w.index].name + "_" + VaweNumber + "_" + w.numrabbits;
        w.index++; if (w.index == w.wave.Count) w.index = 0;
        w.numrabbits++;if (w.numrabbits == w.amountOfRabbits)
        {
            VaweNumber++;wavepause = FramesBetweenWaves;
            if (VaweNumber == waves.Count)
            {
                gameover = true;
                print("Waves Done.");
#if UNITY_EDITOR
                //UnityEditor.EditorApplication.isPaused = true;
#else
                Application.Quit();
#endif
            }
        }

    }

    [System.Serializable]
    public class Wave
    {
        [Header("Total Amount of Rabbits in Wave")]
        public int amountOfRabbits;
        [Header("Prefabs Of Rabbits")]
        public List<GameObject> wave;
        internal int index;
        internal int numrabbits;
    }
}
