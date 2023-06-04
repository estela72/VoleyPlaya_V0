namespace VoleyPlaya.GestionWeb.Infrastructure
{
    public static class Arguments
    {
        public static void Check(object[] args)
        {
            foreach (var obj in args)
            {
                if (obj is string)
                    if (string.IsNullOrEmpty(obj.ToString())) throw new ArgumentException("Argumento no puede ser nulo o vacío.", nameof(obj));
                if (obj is int)
                    if ((int)obj == 0) throw new ArgumentException("Argumento no puede ser nulo o vacío.", nameof(obj));
                if (obj == null) throw new ArgumentException("Argumento no puede ser nulo o vacío.", nameof(obj));
            }
        }
    }
}
