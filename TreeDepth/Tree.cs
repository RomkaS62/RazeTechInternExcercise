using System;
using System.Collections.Generic;
using System.Text;

namespace TreeDepth
{
    class Tree<T>
    {
        public T Data { get; set; }
        private List<Tree<T>> subtrees = new List<Tree<T>>();

        public Tree(T obj)
        {
            Data = obj;
        }

        public Tree<T> Child(int idx)
        {
            return subtrees[idx];
        }

        private static void AssertNotNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
        }

        public Tree<T> this[int index]
        {
            get
            {
                return subtrees[index];
            }
            set
            {
                AssertNotNull(value);
                subtrees[index] = value;
            }
        }

        public Tree<T> Add(T obj)
        {
            subtrees.Add(new Tree<T>(obj));
            return this;
        }

        public Tree<T> Add(Tree<T> subtree)
        {
            subtrees.Add(subtree);
            return this;
        }

        public int Depth()
        {
            int maxDepth = 0;

            for (int i = 0; i < subtrees.Count; i++)
            {
                int depth = subtrees[i].Depth();

                if (depth > maxDepth)
                {
                    maxDepth = depth;
                }
            }

            return maxDepth + 1;
        }

        public void ForEach(Action<T, int> onNode)
        {
            ForEach(onNode, 0);
        }

        private void ForEach(Action<T, int> onNode, int depth)
        {
            onNode(Data, depth);

            for (int i = 0; i < subtrees.Count; i++)
            {
                subtrees[i].ForEach(onNode, depth + 1);
            }
        }
    }
}
