using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonManager : MonoBehaviour {

    public bool HasCaught;
    public Light ligth;
    bool catching = false;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pokemon")
        {
            StartCoroutine("CatchPokemon", other.gameObject);
            
        }
        if (other.gameObject.tag == "Plane")
        {
            if(!catching)
            StartCoroutine("Again");       
        }
    }

    IEnumerator CatchPokemon(GameObject Pokemon)
    {
        catching = true;
        this.GetComponent<DragAndThrow>().isDragable = false;
        transform.Translate(Vector3.up * 1, Space.World);
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().freezeRotation = false;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Pokemon.gameObject.SetActive(false);
      //  Destroy(Pokemon.gameObject);
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(2);
        GameObject.FindGameObjectWithTag("MainCamera").transform.LookAt(this.transform);
        GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<Camera>().fieldOfView = 8.2f;

        
   
        if (Random.value < 0.9)
        {
            yield return new WaitForSeconds(1);
            transform.Rotate(Vector3.right * 5);
            yield return new WaitForSeconds(0.1f);
            transform.Rotate(-Vector3.right * 5);
            if (Random.value < 0.8)
            {

                yield return new WaitForSeconds(1);
                transform.Rotate(Vector3.right * 5);
                yield return new WaitForSeconds(0.1f);
                transform.Rotate(-Vector3.right * 5);

                if (Random.value < 0.85)
                {
                    yield return new WaitForSeconds(1);
                    transform.Rotate(Vector3.right * 5);
                    yield return new WaitForSeconds(0.1f);
                    transform.Rotate(-Vector3.right * 5);

                    yield return new WaitForSeconds(1);
                    transform.Rotate(Vector3.right * 5);
                    yield return new WaitForSeconds(0.1f);
                    transform.Rotate(-Vector3.right * 10);
                    yield return new WaitForSeconds(0.5f);
                    ligth.intensity = 30;
                    yield return new WaitForSeconds(0.2f);
                    ligth.intensity = 0;
                    HasCaught = true;
                    yield return new WaitForSeconds(0.5f);
                    Application.LoadLevel(0);

                   
                }
                else
                {
                    this.GetComponent<DragAndThrow>().isDragable = true;
                    yield return new WaitForSeconds(1);
                    transform.Rotate(Vector3.right * 5);
                    yield return new WaitForSeconds(0.1f);
                    transform.Rotate(-Vector3.right * 5);
                    catching = false;
                    Pokemon.gameObject.SetActive(true);
                    this.gameObject.SetActive(true);
                    this.GetComponent<Rigidbody>().useGravity = false;
                    GameObject.FindGameObjectWithTag("MainCamera").transform.LookAt(GameObject.FindGameObjectWithTag("Pokemon").transform);
                    GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<Camera>().fieldOfView = 60f;
                    this.transform.position = new Vector3(-1.05f, 8f, -12.55f);
                    yield return new WaitForSeconds(10);
                    
                    
                }
            }
            else
            {
                this.GetComponent<DragAndThrow>().isDragable = true;
                yield return new WaitForSeconds(1);
                transform.Rotate(Vector3.right * 5);
                yield return new WaitForSeconds(0.1f);
                transform.Rotate(-Vector3.right * 5);
                catching = false;
                Pokemon.gameObject.SetActive(true);
                this.gameObject.SetActive(true);
                this.GetComponent<Rigidbody>().useGravity = false;
                GameObject.FindGameObjectWithTag("MainCamera").transform.LookAt(GameObject.FindGameObjectWithTag("Pokemon").transform);
                GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<Camera>().fieldOfView = 60f;
                this.transform.position = new Vector3(-1.05f, 8f, -12.55f);
                yield return new WaitForSeconds(10);
               
            }
        }
        else{
            this.GetComponent<DragAndThrow>().isDragable = true;
             yield return new WaitForSeconds(1);
            transform.Rotate(Vector3.right * 5);
            yield return new WaitForSeconds(0.1f);
            transform.Rotate(-Vector3.right * 5);
            catching = false;
            Pokemon.gameObject.SetActive(true);
            this.gameObject.SetActive(true);
            this.GetComponent<Rigidbody>().useGravity = false;
            GameObject.FindGameObjectWithTag("MainCamera").transform.LookAt(GameObject.FindGameObjectWithTag("Pokemon").transform);
            GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<Camera>().fieldOfView =60f;
            this.transform.position = new Vector3(-1.05f, 8f, -12.55f);
            yield return new WaitForSeconds(10);
          
       
        }

    }

    IEnumerator Again()
    {
        transform.Translate(Vector3.up * 1, Space.World);
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;

        this.GetComponent<DragAndThrow>().isDragable = true;
        transform.Rotate(Vector3.right * 5);
        transform.Rotate(-Vector3.right * 5);

        this.GetComponent<Rigidbody>().freezeRotation=true;
        this.gameObject.SetActive(true);
        this.GetComponent<Rigidbody>().useGravity = false;
        GameObject.FindGameObjectWithTag("MainCamera").transform.LookAt(GameObject.FindGameObjectWithTag("Pokemon").transform);
        GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<Camera>().fieldOfView = 60f;
        this.transform.position = new Vector3(-1.05f, 8f, -12.55f);
        yield return new WaitForSeconds(10);
    }

 }

