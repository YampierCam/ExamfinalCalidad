namespace ExamFinal.Models
{
    public class VariableConteo
    {

        public int IdConteo { get; set; }
        public int Cantidad { get; set; }

        public VariableConteo(int idConteo, int cantidad)
        {
            IdConteo = idConteo;
            Cantidad = cantidad;
        }
    }
}