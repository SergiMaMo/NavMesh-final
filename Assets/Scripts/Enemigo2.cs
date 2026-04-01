using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo2 : MonoBehaviour
{
    public Transform routeFather;
    int index = 0;
    Vector3 destination;
    public Vector3 min, max;

    // Start is called before the first frame update
    void Start()
    {
        //1º vamos al primer punto
        destination = routeFather.GetChild(index).position;//Cogemos el pimero
        GetComponent<NavMeshAgent>().SetDestination(destination);
    }

    // Update is called once per frame
    void Update()
    {
        #region Puntos de control
        /*
        //Comprobar si estamos a cierta distancia del destino
        if (Vector3.Distance(transform.position, destination) < 2.5f)
        {
            //Aleatoriamente ->
            index=Random.Range(0, routeFather.childCount);

            //Cogemos el siguiente punto
            //Si es así, vamos al siguiente punto
            //index++;

            if (index >= routeFather.childCount)
            {
                index = 0;
            }
            destination = routeFather.GetChild(index).position;
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }
        */
        #endregion

        #region Ruta Aleatoria Delimitada

        if (Vector3.Distance(transform.position, destination) < 1.5f)
        {
            destination = routeFather.GetChild(Random.Range(index, routeFather.childCount)).position; 
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }

        #endregion

        #region Aleatorio por el NavMesh
        //if (Vector3.Distance(transform.position, destination) < 2.5f)
        //{
        //    Vector3 randomPoint = Random.insideUnitSphere * 50; //Punto aleatorio alrededor nuestro por una distancia
        //    NavMeshHit hit;
        //    NavMesh.SamplePosition(randomPoint, out hit, 50, 1); //1 -> Wallkable
        //    destination = hit.position;
        //    GetComponent<NavMeshAgent>().SetDestination(destination);
        //}
        #endregion
    }
    private Vector3 RandomDestination()
    {
        return new Vector3(Random.Range(min.x, max.x), 0, Random.Range(min.z, max.z));
    }
}
