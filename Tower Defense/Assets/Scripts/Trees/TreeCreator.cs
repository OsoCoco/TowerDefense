using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCreator : MonoBehaviour
{
    /*  public static TreeCreator instance;

      public List<Leave> leaves;
      public GameObject prefabLeave;

      public Leave adan;
      public int maxChilds;
      public int maxGenerations;


      private void Awake()
      {
          if (instance == null)
          {
              instance = this;
          }
          else
          {
              Destroy(this);
          }
      }

      private void Start()
      {
          CreateTree(adan);        
      }

      public void CreateTree(Leave father)
      {
          int gen = father.myGen;
          if (gen < maxGenerations)
          {
              gen += 1;
              for (int i = 0; i < maxChilds; i++)
              {
                  GameObject myChild = Instantiate(prefabLeave, father.transform);
                  father.myChilds.Add(myChild.GetComponent<Leave>());
                  myChild.GetComponent<Leave>().myGen = gen;
                  myChild.GetComponent<Leave>().myFather = father;
              }

          }
      }

      public void NormalSearch()
      {
          for (int i = 0; i < leaves.Count - 1; i++)
          {
              if (leaves[i].isTheChosenOne == true)
              {
                  Debug.Log("ELEGIDO");
              }
              else
              {
                  Debug.Log("BUSCANDO...");
              }
          }

      }

      public void SetTheChosenOne()
      {
          int random = Random.Range(2, leaves.Count);
          leaves[random].isTheChosenOne = true;
          Debug.Log("EL ELEGIDO A NACIDO");
      }

      public void BFS()
      {

      }-*/

    private void Start()
    {
        Tree t = new Tree(4);
        t.AddEdge(0, 1);
        t.AddEdge(0, 2);
        t.AddEdge(1, 2);
        t.AddEdge(2, 0);
        t.AddEdge(2, 3);
        t.AddEdge(3, 3);

        Debug.Log("BUSQUEDA BFS");
        t.BFS(2);
        Debug.Log("BUSQUEDA DFS");
        t.DFS();
    }

    public class Tree
    {
        private int totalVertices;
        LinkedList<int>[] adjanceList;

        public Tree(int V)
        {
            adjanceList = new LinkedList<int>[V];
            for (int i = 0; i < adjanceList.Length; i++)
            {
                adjanceList[i] = new LinkedList<int>();
            }
            totalVertices = V;
        }

        public void AddEdge(int v, int w)
        {
            adjanceList[v].AddLast(w);
        }

        public void BFS(int index)
        {
            //
            bool[] visited = new bool[totalVertices];

            for (int i = 0; i < totalVertices; i++)
            {
                visited[i] = false;
            }

            LinkedList<int> queue = new LinkedList<int>();
            visited[index] = true;
            queue.AddLast(index);

            while(queue.Any())
            {
                index = queue.First();
                Debug.Log(index + " ");
                queue.RemoveFirst();

                LinkedList<int> list = adjanceList[index];
                foreach(var val in list)
                {
                    if (!visited[val])
                    {
                        visited[val] = true;
                        queue.AddLast(val);
                    }
                }
            }

        }

        private void DFSUtil(int v, bool[] visited)
        {
            visited[v] = true;
            Debug.Log(v + " ");

            foreach(int i in adjanceList[v])
            {
                int n = i;
                if (!visited[n])
                    DFSUtil(n, visited);
            }
        }

        public void DFS()
        {
            bool[] visited = new bool[totalVertices];
            for (int i = 0; i < totalVertices; i++)
            {
                if(visited[i]==false)
                {
                    DFSUtil(i, visited);
                }
            }
        }

    }
}
