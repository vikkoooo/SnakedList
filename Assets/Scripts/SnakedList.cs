using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakedList<T>
{
	private int length;
	private Node<T> head;

	// Initialize list length at 0
	public SnakedList()
	{
		length = 0;
	}

	public void InsertAtEnd(T data)
	{
		Node<T> newNode = new Node<T>(data);

		// If empty list
		if (head == null)
		{
			head = newNode;
			length++;
			return;
		}

		Node<T> last = head;
		while (last.Next != null)
		{
			last = last.Next;
		}

		last.Next = newNode;
		length++;
	}

	// To access the N:th element in the list
	public Node<T> GetElementN(int n)
	{
		Node<T> temp = head;

		if (length < n)
		{
			return null;
		}

		for (int i = 0; i < n; i++)
		{
			temp = temp.Next;
		}

		return temp;
	}

	// Length getter
	public int Length
	{
		get { return length; }
	}
}

// Basic node class
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

	// Get set next node
	public Node<T> Next
	{
		get { return this.next; }
		set { this.next = value; }
	}
}