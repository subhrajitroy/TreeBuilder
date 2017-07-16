using System.Linq;
using NUnit.Framework;

namespace TreeBuilder.UnitTests
{
    [TestFixture]
    public class NodeTest
    {
        [Test]
        public void ShouldAddImmediateChild()
        {
            var root = new Node<string>("Root", "/root");
            var c1 = new Node<string>("C1","/root/foo");
            root.AddDescendent(c1);
            var c2 = new Node<string>("C2","/root/bar");
            root.AddDescendent(c2);
            var nodeChildren = root.Children;
            Assert.That(nodeChildren.Count,Is.EqualTo(2));
            Assert.That(nodeChildren.Find(c => c.Path.Equals(c1.Path)),Is.EqualTo(c1));
            Assert.That(nodeChildren.Find(c => c.Path.Equals(c2.Path)),Is.EqualTo(c2));
        }

        [Test]
        public void ShouldAddToChildIfNotImmediateAndChildExists()
        {
            var root = new Node<string>("Root", "/root");
            var c1 = new Node<string>("C1", "/root/foo");
            root.AddDescendent(c1);
            var c2 = new Node<string>("C2", "/root/foo/bar");
            root.AddDescendent(c2);
            var nodeChildren = root.Children;
            Assert.That(nodeChildren.Count, Is.EqualTo(1));
            Assert.That(nodeChildren.Find(c => c.Path.Equals(c1.Path)), Is.EqualTo(c1));

            var c1Children = c1.Children;
            Assert.That(c1Children.Count,Is.EqualTo(1));
            Assert.That(c1Children.First(),Is.EqualTo(c2));
        }

        [Test]
        public void ShouldAddAllNodesTillLeafIfNotAnImmediateChildAndNoNextAncestorExists()
        {
            var root = new Node<string>("Root", "/root");
            var leaf = new Node<string>("C1", "/root/foo/bar/etc");
            root.AddDescendent(leaf);
            var rootChildren = root.Children;
           Assert.That(rootChildren.Count,Is.EqualTo(1));
            var child1 = rootChildren.First();
            Assert.That(child1,Is.EqualTo(new Node<string>("/root/foo")));

            Assert.That(child1.Children.Count,Is.EqualTo(1));
            var child11 = child1.Children.First();
            Assert.That(child11, Is.EqualTo(new Node<string>("/root/foo/bar")));

            Assert.That(child11.Children.Count, Is.EqualTo(1));
            Assert.That(child11.Children.First(), Is.EqualTo(leaf));

        }
    }
}