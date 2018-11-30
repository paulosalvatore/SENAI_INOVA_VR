using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zumbi : MonoBehaviour {

	Animator animator;
	Rigidbody rb;

	bool andando = false;
	public float delayAndar = 1f;
	public float velocidade = 0.35f;

	GameObject jogador;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();

		jogador = GameObject.Find("Jogador");

		Invoke("Andar", delayAndar);

		transform.LookAt(jogador.transform);
	}

	void Andar()
	{
		transform.LookAt(jogador.transform);
		andando = true;
	}

	// Update is called once per frame
	void Update () {
		if (andando)
		{
			rb.velocity = (jogador.transform.position - transform.position).normalized * velocidade;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Projétil"))
		{
			Destroy(other.gameObject);
			animator.SetTrigger("Morrer");
			andando = false;
		}
	}
}
