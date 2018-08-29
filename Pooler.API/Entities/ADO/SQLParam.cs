namespace Pooler.API.Entities.ADO
{
    public class SQLParam
    {
        public SQLParam()
        {
        }

        public SQLParam(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }

        public string Value { get; set; }

    }
}