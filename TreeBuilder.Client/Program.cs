using System;
using Newtonsoft.Json;

namespace TreeBuilder.Client
{
    static class Program
    {
        private static void Main(string[] args)
        {
            var node = new Node<int>(1, "/root");
            node.AddDescendent(new Node<int>(2, "/root/path1/path2"));
            node.AddDescendent(new Node<int>(2, "/root/path1/path3"));
            node.AddDescendent(new Node<int>(2, "/root/path1/path3/path33"));
            node.AddDescendent(new Node<int>(21, "root/path1/path11/path13"));
            node.AddDescendent(new Node<int>(3, "root/path1/path2/path3"));
            node.AddDescendent(new Node<int>(53, "root/path1/path2/path4"));
            var serializeObject = JsonConvert.SerializeObject(node,Formatting.Indented);
            Console.WriteLine(serializeObject);
        }
    }
}
