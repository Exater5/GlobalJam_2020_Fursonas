using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3_GameManager : MonoBehaviour
{
    [System.Serializable]
    public class Tablero
    {
        public int columna;
        public int fila;
        public List<List<Puzzle3_Pieza>> piezas;
    }

    public Tablero puzzle;

    [SerializeField]
    GameObject[] tuberias;
    public GameObject inicio;
    public GameObject final;

    public Transform inicioPos;
    public Transform finalPos;

    public int columns;
    public int rows;

    [HideInInspector]
    public bool piezaSeleccionada = false;
    [HideInInspector]
    public GameObject pieza;

    List<Vector2> gridPositions = new List<Vector2>();

    int piezasElegidas = 0;
    [SerializeField]
    Vector2 p1, p2;

    bool victoria = false;

    public void ElegirPieza(Vector2 index)
    {
        if (piezasElegidas == 0)
        {
            p1 = index;
            piezasElegidas++;
            puzzle.piezas[(int)p1.x][(int)p1.y].GetComponent<SpriteRenderer>();
        }
        else
        {
            p2 = index;
            CambiarPieza();
            piezasElegidas = 0;
        }
    }

    public void CambiarPieza()
    {
        puzzle.piezas[(int)p1.x][(int)p1.y].SetIndex(p2);
        puzzle.piezas[(int)p2.x][(int)p2.y].SetIndex(p1);

        Vector3 pos = puzzle.piezas[(int)p1.x][(int)p1.y].transform.position;
        puzzle.piezas[(int)p1.x][(int)p1.y].transform.position = puzzle.piezas[(int)p2.x][(int)p2.y].transform.position;
        puzzle.piezas[(int)p2.x][(int)p2.y].transform.position = pos;

        Puzzle3_Pieza piezaAux = puzzle.piezas[(int)p1.x][(int)p1.y];
        puzzle.piezas[(int)p1.x][(int)p1.y] = puzzle.piezas[(int)p2.x][(int)p2.y];
        puzzle.piezas[(int)p2.x][(int)p2.y] = piezaAux;

        ResetEstado();
        ComprobarEstado();
        piezasElegidas = 0;
    }

    void InitialiseGridPosition()
    {
        puzzle.piezas = new List<List<Puzzle3_Pieza>>();
        
        for(int i = 0; i< rows; i++)
        {
            puzzle.piezas.Add(new List<Puzzle3_Pieza>());
            for(int j=0; j< columns; j++)
            {
                GameObject pieza = Instantiate(tuberias[Random.Range(0,tuberias.Length)], new Vector3(j, i, 0), Quaternion.identity);
                pieza.GetComponent<Puzzle3_Pieza>().SetIndex(new Vector2(i,j));
                puzzle.piezas[i].Add(pieza.GetComponent<Puzzle3_Pieza>());
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ComprobarEstado();
        }
    }

    void Start()
    {
        InitialiseGridPosition();
        GirarPiezas();

        Instantiate(inicio, inicioPos);
        Instantiate(final, finalPos);

        ComprobarEstado();
    }

    void InstantiateObjectsAtRandom(GameObject objectList, int minRange, int maxRange, GameObject board)
    {
        int randomAmountOfObjects = Random.Range(minRange, maxRange + 1);

        for (int i = 0; i < randomAmountOfObjects; i++)
        {
            Vector2 randomPosition = GetRandomPosition(); Instantiate(objectList, randomPosition, Quaternion.identity, board.transform);
        }
    }

    void GirarPiezas()
    {
        foreach (var pieza in GameObject.FindGameObjectsWithTag("Pieza"))
        {
            int rotaciones = Random.Range(0, 4);

            for (int i = 0; i < rotaciones; i++)
            {
                pieza.GetComponent<Puzzle3_Pieza>().RotarPieza();
            }
        }
    }

    public void ComprobarEstado()
    {
        bool somethingChanged = false;

        if (puzzle.piezas[(int)inicioPos.position.y][(int)inicioPos.position.x + 1].valores[3] == 1)
        {
            puzzle.piezas[(int)inicioPos.position.y][(int)inicioPos.position.x + 1]._estaActiva = true;
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                if (puzzle.piezas[r][c]._estaActiva)
                {
                    //Compara Arriba
                    if (puzzle.piezas[r][c].valores[0] == 1 && r + 1 < rows && puzzle.piezas[r + 1][c].valores[2] == 1 && !puzzle.piezas[r + 1][c]._estaActiva)
                    {
                        puzzle.piezas[r + 1][c]._estaActiva = true;
                        somethingChanged = true;
                    }
                    //Compara Derecha
                    if (puzzle.piezas[r][c].valores[1] == 1 && c + 1 < columns && puzzle.piezas[r][c + 1].valores[3] == 1 && !puzzle.piezas[r][c + 1]._estaActiva)
                    {
                        puzzle.piezas[r][c + 1]._estaActiva = true;
                        somethingChanged = true;
                    }
                    //Compara Abajo
                    if (puzzle.piezas[r][c].valores[2] == 1 && r > 0 && puzzle.piezas[r - 1][c].valores[0] == 1 && !puzzle.piezas[r - 1][c]._estaActiva)
                    {
                        puzzle.piezas[r - 1][c]._estaActiva = true;
                        somethingChanged = true;
                    }
                    //Compara Izquierda
                    if (puzzle.piezas[r][c].valores[3] == 1 && c < 0 && puzzle.piezas[r][c - 1].valores[1] == 1 && !puzzle.piezas[r][c - 1]._estaActiva)
                    {
                        puzzle.piezas[r][c - 1]._estaActiva = true;
                        somethingChanged = true;
                    }
                }
            }
        }
 
        if (somethingChanged)
        {
            ComprobarEstado();
        }

        if (puzzle.piezas[(int)finalPos.position.y][(int)finalPos.position.x - 1].valores[1] == 1 && puzzle.piezas[(int)finalPos.position.y][(int)finalPos.position.x - 1]._estaActiva)
        {
            GameObject.Find("Final(Clone)").GetComponent<Puzzle3_Pieza>()._estaActiva = true;
            victoria = true;
            print("Victoria");
        }
    }

    void ResetEstado()
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                puzzle.piezas[r][c]._estaActiva = false;
            }
        }
    }

    Vector2 GetRandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector2 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }
}