class Kayak : Equipo
{
    //propiedad publica
    public int ChalecosRequerido;

    //metodo constructor kayak
    public Kayak(string Codigo, string Descripcion, double Deposito, int ChalecosRequerido, bool Disponible) : base(Codigo, Descripcion, Deposito, Disponible)
    {
        this.ChalecosRequerido = ChalecosRequerido;
    }

    //metodo demostrar detalles de kayak
    public override void Detalle()
    {
        Console.WriteLine($"Código: {Codigo}, Descripción: {Descripcion}, Depósito: {Deposito} Chalecos {ChalecosRequerido}, Disponible: {Disponible}");
    }
}