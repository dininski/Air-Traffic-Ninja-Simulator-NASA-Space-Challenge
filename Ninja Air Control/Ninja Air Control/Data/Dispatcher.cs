namespace NinjaAirControl.Data
{
    public class Person
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                name = value;
            }
        }

        public Person(string name)
        {
            this.Name = name;
        }
    }
}