Usage

var node = new Node<int>(1, "/root");
            node.AddDescendent(new Node<int>(2, "/root/path1/path2"));
            node.AddDescendent(new Node<int>(2, "/root/path1/path3"));
            node.AddDescendent(new Node<int>(2, "/root/path1/path3/path33"));
            node.AddDescendent(new Node<int>(21, "root/path1/path11/path13"));
            node.AddDescendent(new Node<int>(3, "root/path1/path2/path3"));
            node.AddDescendent(new Node<int>(53, "root/path1/path2/path4"));
            





Result will be a tree that will have a JSON representation like

{
  "Path": "/root",
  "Value": 1,
  "Children": [
    {
      "Path": "/root/path1",
      "Value": 0,
      "Children": [
        {
          "Path": "/root/path1/path2",
          "Value": 2,
          "Children": [
            {
              "Path": "/root/path1/path2/path3",
              "Value": 3,
              "Children": []
            },
            {
              "Path": "/root/path1/path2/path4",
              "Value": 53,
              "Children": []
            }
          ]
        },
        {
          "Path": "/root/path1/path3",
          "Value": 2,
          "Children": [
            {
              "Path": "/root/path1/path3/path33",
              "Value": 2,
              "Children": []
            }
          ]
        },
        {
          "Path": "/root/path1/path11",
          "Value": 0,
          "Children": [
            {
              "Path": "/root/path1/path11/path13",
              "Value": 21,
              "Children": []
            }
          ]
        }
      ]
    }
  ]
}
