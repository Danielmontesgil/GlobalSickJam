using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagers : MonoBehaviour {

    private static GameManagers instance;

	 public static GameManagers Instance { get {return instance;}}

    [SerializeField]
    private string Dia3;
    [SerializeField]
    private string scenaFinalGano;
    [SerializeField]
    private string scenaFinalPerdio;
    [SerializeField]
    private string scenaFinalCapturado;
    [SerializeField]
    public float time = 180;
    [HideInInspector][SerializeField] public float t;

    public int lifes = 100;
	 public int puntajeGlobal=0;
	 //Dia 1
     //variable que dice que mesa puso chinches
     public int Dia1ChincheMesa;
     //variable que dice si activo bien el gas dia 1
	 public bool Dia1GasMultitud;
    //variable que dice si activo la solucion
	 public bool Dia1SolucionGripe;
     
   
	 //dia2
	 //variable que dice si inyecto de forma correcta
	 public bool Dia2Inyectar;
    //variable que dice si activo gas dia2
	public bool Dia2GasCarpa;
	//variable que dice si activo jabon dia2
	public bool Dia2Jabon;
    
    
	//Dia 3
	//Variable que dice si puso polvo en pizza
	public bool Dia3PolvoPizza;

	//Variable que dice si puso solucion en tinto
	public bool Dia3SolucionTinto;

	public bool Dia3Jeringa;
	
   public void UpdateScore(int points)
    {
        puntajeGlobal += points;
    }

	public int PuntajeGlob{
        get { return puntajeGlobal; }
        set { puntajeGlobal = value; }
    }
	//Set Gets Dia 1
    public int ChincheDia1{
        get { return Dia1ChincheMesa; }
        set { Dia1ChincheMesa = value; }
    }

	public bool GasDia1{
        get { return Dia1GasMultitud; }
        set { Dia1GasMultitud = value; }
    }

	public bool SolucionDia1{
        get { return Dia1SolucionGripe; }
        set { Dia1SolucionGripe = value; }
    }
	//Set Gets Dia 2
	public bool inyectarDia2{
        get { return Dia2Inyectar; }
        set { Dia2Inyectar = value; }
    }
    public bool GasCarpaDia2{
        get { return Dia2GasCarpa; }
        set { Dia2GasCarpa = value; }
    }

    public bool JabonDia2{
		get{return Dia2Jabon;}
		set{Dia2Jabon=value;}
	}
	//Set Gets dia 3
	public bool PolvoPizzaDia3{
		get{return Dia3PolvoPizza;}
		set{Dia3PolvoPizza=value;}
	}
	public bool SolucionTintoDia3{
		get{return Dia3SolucionTinto;}
		set{Dia3SolucionTinto=value;}
	}
	public bool JerigaDia3{
		get{return Dia3Jeringa;}
		set{Dia3Jeringa=value;}
	}

    private void OnEnable()
    {
        SceneController.onLoadAdd += Timer;
    }

    private void OnDisable()
    {
        SceneController.onLoadAdd += Timer;
    }

    void Start () {

        
		if(instance==null){
			instance=this;
		}else{
			Destroy(this.gameObject);
		}
		 DontDestroyOnLoad(this.gameObject);	
	}

    void Timer()
    {
        StartCoroutine(DayTimer());
    }

    public void FinalDay()
    {
        if (SceneManager.GetActiveScene().name == Dia3)
        {
            if(t <= 0)
            {
                SceneManager.LoadScene(scenaFinalPerdio);
            }

            if (puntajeGlobal <= 9)
            {
                SceneManager.LoadScene(scenaFinalPerdio);
            }
            if (puntajeGlobal>=10 || puntajeGlobal<=15)
            {
                SceneManager.LoadScene(scenaFinalCapturado);
            }
            if (puntajeGlobal >= 16 || puntajeGlobal <= 21)
            {
                SceneManager.LoadScene(scenaFinalGano);
            }
        }
    }

    public void GameOver(bool mono)
    {
        if (mono)
        {
            SceneManager.LoadScene(scenaFinalPerdio);
        }
        else
        {
            SceneManager.LoadScene(scenaFinalCapturado);
        }
        
    }
    public int contador=1;
    IEnumerator DayTimer()
    {
        t = time;

        while(t > 0)
        {
            t -= Time.deltaTime;

            yield return null;
        }
        SceneController.Instance.RemoveScene();
        contador++;
        string levelName = string.Format("level{0}", contador);
        SceneController.Instance.LoadLevel(levelName);
    }
}
