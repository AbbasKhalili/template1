namespace Project.Domain
{
    public class Project
    {
        public long Id { get; private set; }
        public string Name { get; private set; }


        protected Project() { }
        public Project(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
