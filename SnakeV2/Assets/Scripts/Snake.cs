using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Snake : MonoBehaviour
{
    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    public Vector2 direction = Vector2.right;
    private Vector2 input;
    public int initialSize = 4;
    public int life = 3;
    public GameObject objectToInstanttiate;
    

    private void Start()
    {
        
        ResetState();
    }

    private void Update()
    {
        // Autoriser uniquement la rotation vers le haut ou vers le bas lors du déplacement dans l'axe des x
        if (direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
            {
                input = Vector2.up;
            } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) 
            {
                input = Vector2.down;
            }
        }
        // Autoriser uniquement les virages à gauche ou à droite tout en se déplaçant sur l'axe y
        else if (direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) 
            {
                input = Vector2.right;
            } else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) 
            {
                input = Vector2.left;
            }
            
        }
    }

    private void FixedUpdate()
    {
        // Définir la nouvelle direction en fonction de l'entrée
        if (input != Vector2.zero) 
        {
            direction = input;
        }

        // Définit la position de chaque segment pour qu'elle soit la même que celle qu'il suit.
        for (int i = segments.Count - 1; i > 0; i--) 
        {
            segments[i].position = segments[i - 1].position;
        }

        // Déplacez le serpent dans la direction à laquelle il fait face
        // Arrondir les valeurs pour s'assurer qu'elles s'alignent sur la grille
        float x = Mathf.Round(transform.position.x) + direction.x;
        float y = Mathf.Round(transform.position.y) + direction.y;

        transform.position = new Vector2(x, y);

        //Fin de la partie
             if (life == 0)
            {
                Instantiate(objectToInstanttiate);
                Time.timeScale = 0;
                GameOver(); 
            }
    }

    IEnumerator TempsBonusEscar()
    {
        Time.fixedDeltaTime = 0.06f;
        yield return new WaitForSeconds(5);
        Time.fixedDeltaTime = 0.04f;
    }
    IEnumerator TempsBonusFiole()
    {
        DesGrow();DesGrow();DesGrow();DesGrow();DesGrow();DesGrow();DesGrow();DesGrow();DesGrow();DesGrow();
        yield return new WaitForSeconds(5);
        Grow();Grow();Grow();Grow();Grow();Grow();Grow();Grow();Grow();Grow();
        
    }
    IEnumerator TempsMalusSOS()
    {
        Time.fixedDeltaTime = 0.0275f;
        yield return new WaitForSeconds(5);
        Time.fixedDeltaTime = 0.04f;
    }

    IEnumerator TempsMalusCup()
    {
        Grow();Grow();Grow();Grow();Grow();Grow();Grow();Grow();Grow();Grow();
        yield return new WaitForSeconds(5);
        DesGrow();DesGrow();DesGrow();DesGrow();DesGrow();DesGrow();DesGrow();DesGrow();DesGrow();DesGrow();
    }


    public void GameOver()
    { 
        SceneManager.LoadScene(0);
    }

    public void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }
    public void DesGrow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Remove(segment);
    }


    public void ResetState()
    {
        direction = Vector2.right;
        transform.position = Vector3.zero;

        // Commencez à 1 pour ne pas détruire la tête
        for (int i = 1; i < segments.Count; i++) 
        {
            Destroy(segments[i].gameObject);
        }

        // Effacez la liste mais rajoutez ceci comme tête
        segments.Clear();
        segments.Add(transform);

        // -1 puisque la tête est déjà dans la liste
        for (int i = 0; i < initialSize - 1; i++) 
        {
            Grow();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food")) 
        {
            Grow();
            ScoreManager.instance.AddPoint();
        } 

        if (other.gameObject.CompareTag("Obstacle")) 
        {
            ResetState();
            life --; 
        }

        if (other.gameObject.CompareTag("SOS")) 
        {
            StartCoroutine(TempsMalusSOS());
        }

        if (other.gameObject.CompareTag("Escargot")) 
        {
            StartCoroutine(TempsBonusEscar());
        }
        
        if (other.gameObject.CompareTag("Cupcake")) 
        {
            StartCoroutine(TempsMalusCup());
        }

        if (other.gameObject.CompareTag("Fiole")) 
        {
            StartCoroutine(TempsBonusFiole());
        }
        
    }


}
