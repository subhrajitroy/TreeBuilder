namespace TreeBuilder.Client
{
    public class Permission
    {
        private readonly string _path;
        private readonly string _acess;

        public Permission(string path, string acess)
        {
            _path = path;
            _acess = acess;
        }
    }
}