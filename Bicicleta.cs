class Bicicleta : Equipo
{
    //propiedad publica
    public bool EsMontana;

    //metodo constructor con heredación de bicicleta
    public Bicicleta(string Codigo, string Descripcion, double Deposito, bool EsMontana, bool Disponible) : base(Codigo, Descripcion, Deposito, Disponible)
    {
        this.EsMontana = EsMontana;
    }

    //Mostar detalle
    public override void Detalle()
        {
            Console.WriteLine($"Código: {Codigo}, Descripción: {Descripcion}, Montaña: {EsMontana}, Depósito: {Deposito} Disponible: {Disponible}");
        }
}