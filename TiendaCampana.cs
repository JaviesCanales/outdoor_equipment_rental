class TiendaCampana : Equipo
{
    //propiedad equipo
    public int CapacidadPersonas;

    //metodo constructor de tienda de campaña
    public TiendaCampana(string Codigo, string Descripcion, double Deposito, int CapacidadPersonas, bool Disponible) : base(Codigo, Descripcion, Deposito, Disponible)
    {
        this.CapacidadPersonas = CapacidadPersonas;
    }

    //detalles de tienda de campaña
    public override void Detalle()
    {
        Console.WriteLine($"Código: {Codigo}, Descripción: {Descripcion}, Depósito: {Deposito} Capacidad: {CapacidadPersonas}, Disponible: {Disponible}");
    }
}