using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApp4
{
    class Program
    {

        static void Main(string[] args)
        {
            Test test = new Test();
            List<int> baseArr = new List<int>() { 232, 40, 15, 16, 47, 8, 155, 22, 23 };
            List<int> sortedArray = test.QuickSort(baseArr);
            foreach (var item in sortedArray)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
    public class Test
    {
        public void GetFunWithDelegate(List<User> users)
        {
            var result = users.Where(where);
            bool where(User user) => String.Compare(user.Name, "abd", StringComparison.CurrentCultureIgnoreCase) == 0;

            var result2 = users.Select(condition);
            string condition(User user) => user.Name;

            var result3 = users.TakeWhile(condition1);
            bool condition1(User user) => (user.LastName == "asd" && user.Age > 25);

            bool condition4(string name) => (name == "asd");
            var x = users.Select(condition).Where(condition4);

            void Add(User user) => user.Age = user.Age + 1;
            users.ForEach(Add);

            users.Find(where);
        }
        public int BinarySearch(int result)
        {
            int[] array = new int[] { 2, 4, 5, 6, 7, 8, 15, 22, 23 };
            var indL = 0;
            var indH = array.Length;
            int indM = 0;
            while (indL < indH)
            {
                indM = ((indH + indL) / 2);
                if (array[indM] < result)
                {
                    indL = indM - 1;
                }
                else if (array[indM] > result)
                {
                    indH = indM + 1;
                }
                else if (array[indM] == result)
                    return indM;
            }
            return -1;
        }
        public List<int> TwoArraysSort()
        {
            int[] baseArr = new int[] { 232, 40, 15, 16, 47, 8, 155, 22, 23 };
            List<int> array = new List<int>(baseArr);
            List<int> sortArray = new List<int>();

            for (int i = array.Count - 1; i >= 0; i--)
            {
                int smallest = array.ElementAt(i);
                for (int y = 1; y < array.Count; y++)
                {
                    if (array.ElementAt(y) < smallest)
                    {
                        smallest = array.ElementAt(y);
                    }
                }
                sortArray.Add(smallest);
                array.Remove(smallest);
            }
            return sortArray;
        }
        public List<int> QuickSort(List<int> baseArr)
        {
            if (baseArr.Count < 2)
            {
                return baseArr;
            }
            else
            {
                List<int> less = new List<int>();
                List<int> greater = new List<int>();
                var midInd = Math.Abs(baseArr.Count / 2);
                var mid = baseArr[midInd];
                foreach (var item in baseArr)
                {
                    if (item < mid) less.Add(item);
                    else if (item > mid) greater.Add(item);
                }

                return QuickSort(less).Append(mid).Concat(QuickSort(greater)).ToList();
            }
 
}
    }
    public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    //-----
    
}

class Node
{
    public string Name { get; }
    public List<Node> Children { get; }

    public Node(string name)
    {
        Name = name;
        Children = new List<Node>();
    }

    public Node AddChildren(Node node, bool bidirect = true)
    {
        Children.Add(node);
        if (bidirect)
        {
            node.Children.Add(this);
        }
        return this;
    }

    public void Handler()
    {
        Console.WriteLine($"visited {this.Name}");
    }
}

class DepthFirstSearch
{
    private HashSet<Node> visited;
    private LinkedList<Node> path_DFS;
    private Node goal;
    public LinkedList<Node> DFS(Node start, Node goal)
    {
        visited = new HashSet<Node>();
        path_DFS = new LinkedList<Node>();
        this.goal = goal;
        DFS(start);
        if (path_DFS.Count > 0)
        {
            path_DFS.AddFirst(start);
        }
        return path_DFS;
    }

    private bool DFS(Node node)
    {
        node.Handler();
        if (node == goal)
        {
            return true;
        }
        visited.Add(node);
        foreach (var child in node.Children.Where(x => !visited.Contains(x)))
        {
            if (DFS(child))
            {
                path_DFS.AddFirst(child);
                return true;
            }
        }
        return false;
    }

    internal object DFS(Node n06, Node n10, int v)
    {
        throw new NotImplementedException();
    }
}
class BreadthFirstSearch
    {
        private HashSet<Node> visited;
        private LinkedList<Node> path_BFS;
        private Node goal;

        public LinkedList<Node> BFS(Node start, Node goal)
        {
            visited = new HashSet<Node>();
            path_BFS = new LinkedList<Node>();
            this.goal = goal;
            BFS(start);
            if (path_BFS.Count > 0)
            {
                path_BFS.AddLast(start);
            }
            return path_BFS;
        }

        private bool BFS(Node node)
        {
            node.Handler();
            if (node == goal)
            {
                return true;
            }
            visited.Add(node);
            foreach (var child in node.Children.Where(x => !visited.Contains(x)))
            {
                if (BFS(child))
                {
                    path_BFS.AddLast(child);
                    return true;
                }
            }
            return false;
        }
    private static void PrintPath_BFS(LinkedList<Node> path_BFS)
    {
        Console.WriteLine();
        if (path_BFS.Count == 0)
        {
            Console.WriteLine("You shall not pass!");
        }
        else
        {
            Console.WriteLine(string.Join(" -> ", path_BFS.Select(x => x.Name)));
        }
        Console.Read();
    }
}
    //---

