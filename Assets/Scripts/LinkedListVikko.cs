using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LinkedListVikko<T>
{
	public int length;
	private Node<T> head;

	public LinkedListVikko()
	{
		length = 0;
	}


	public void InsertAtFront(T data)
	{
		Node<T> newNode = new Node<T>(data);
		newNode.Next = head;
		head = newNode;
		length++;
	}

	// public void InsertAtEnd(Transform data)
	// {
	//
	// 	Node newNode = new Node(data);
	// 	length++;
	// 	
	// 	if (head == null)
	// 	{
	// 		head = newNode;
	// 	}
	// 	else
	// 	{
	// 		Node lastNode = GetLastNode();
	// 		lastNode.Next = newNode;
	// 		newNode.
	// 		
	// 	}
	// }
	
	// // This is used to traverse the list
	// public int tranverse(Node<T> headNode)
	// {
	// 	int length = 0;
	//
	// 	Node<T> currentNode = headNode;
	//
	// 	while (currentNode != null)
	// 	{
	// 		length++;
	// 		currentNode = currentNode.next;
	// 	}
	// 	return length;
	// }
	
	
}

public class Node<T>
{
	private T data; // Set to whatever datatype needed
	private Node<T> next;

	// Constructor
	public Node(T data)
	{
		this.data = data;
	}
	
	// To get or set the data
	public T Data
	{
		get { return this.data; }
		set { this.data = value; }
	}
	
	public Node<T> Next
	{
		get { return this.next; }
		set { this.next = value; }
	}


	
	
}