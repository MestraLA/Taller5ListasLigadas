
using Taller5ListasLigadas.Backend.Entities;

namespace Taller5ListasLigadas.Backend.DataStructures;

public class DoublyLinkedList<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    private readonly IComparer<T> _comparer;

    public int Count { get; private set; }

    public bool IsEmpty => Count == 0;

    public DoublyLinkedList()
    {
        _comparer = Comparer<T>.Default;
    }

    public DoublyLinkedList(IComparer<T> comparer)
    {
        _comparer = comparer;
    }

    public void AddSorted(T data)
    {
        Node<T> newNode = new Node<T>(data);

        if (IsEmpty)
        {
            _head = newNode;
            _tail = newNode;
        }
        else if (_comparer.Compare(data, _head!.Data) <= 0)
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
        }
        else
        {
            Node<T> current = _head;

            while (current.Next != null &&
                   _comparer.Compare(current.Next.Data, data) <= 0)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            newNode.Previous = current;

            if (current.Next != null)
            {
                current.Next.Previous = newNode;
            }
            else
            {
                _tail = newNode;
            }

            current.Next = newNode;
        }

        Count++;
    }


    public IEnumerable<T> GetForward()
    {
        Node<T>? current = _head;

        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    public IEnumerable<T> GetBackward()
    {
        Node<T>? current = _tail;

        while (current != null)
        {
            yield return current.Data;
            current = current.Previous;
        }
    }


    public void SortDescending()
    {
        if (Count <= 1)
        {
            return;
        }

        bool swapped;

        do
        {
            swapped = false;

            Node<T>? current = _head;

            while (current?.Next != null)
            {
                if (_comparer.Compare(current.Data, current.Next.Data) < 0)
                {
                    T temporary = current.Data;

                    current.Data = current.Next.Data;
                    current.Next.Data = temporary;

                    swapped = true;
                }

                current = current.Next;
            }

        } while (swapped);
    }



    public bool Contains(T data)
    {
        Node<T>? current = _head;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, data))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }



    public bool RemoveOne(T data)
    {
        Node<T>? current = _head;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, data))
            {
                RemoveNode(current);
                return true;
            }

            current = current.Next;
        }

        return false;
    }



    public int RemoveAll(T data)
    {
        int removed = 0;

        Node<T>? current = _head;

        while (current != null)
        {
            Node<T>? next = current.Next;

            if (EqualityComparer<T>.Default.Equals(current.Data, data))
            {
                RemoveNode(current);
                removed++;
            }

            current = next;
        }

        return removed;
    }



    private void RemoveNode(Node<T> node)
    {
        if (node.Previous != null)
        {
            node.Previous.Next = node.Next;
        }
        else
        {
            _head = node.Next;
        }

        if (node.Next != null)
        {
            node.Next.Previous = node.Previous;
        }
        else
        {
            _tail = node.Previous;
        }

        node.Previous = null;
        node.Next = null;

        Count--;
    }



    public void SortAscending()
    {
        if (Count <= 1)
        {
            return;
        }

        bool swapped;

        do
        {
            swapped = false;

            Node<T>? current = _head;

            while (current?.Next != null)
            {
                if (_comparer.Compare(current.Data, current.Next.Data) > 0)
                {
                    T temporary = current.Data;

                    current.Data = current.Next.Data;
                    current.Next.Data = temporary;

                    swapped = true;
                }

                current = current.Next;
            }

        } while (swapped);
    }


}
