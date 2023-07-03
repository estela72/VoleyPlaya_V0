namespace Ejemplo.Client.Model
{
    public class Dummy
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public override string ToString()
        {
            return "Dummy [Id ="+Id+" Text="+Text+"]";
        }
    }
}
