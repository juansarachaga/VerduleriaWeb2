namespace VerduleriaWeb.Entidades
{
    public class Venta
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
    }
}
