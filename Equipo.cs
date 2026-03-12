class Equipo
{
    //propiedades privadas
    private string codigo;
    private string descripcion;
    private bool disponible;
    private double deposito;

    //propiedades publicas con get set
    public string Codigo
    {
        get { return codigo; }
        set { codigo = value; }
    }

    public string Descripcion
    {
        get { return descripcion; }
        set { descripcion = value; }
    }

    public bool Disponible
    {
        get { return disponible; }
        set { disponible = value; }
    }
    public double Deposito
        {
            get { return deposito; }
            set { deposito = value;}
        }
    
    //metodo constructor de equipo
    public Equipo(string Codigo, string Descripcion, double Deposito, bool Disponible)
    {
        this.Codigo = Codigo;
        this.Descripcion = Descripcion;
        this.Deposito = Deposito;
        this.Disponible = Disponible;
    }

    //mostrar detalles de equipo
    public virtual void Detalle()
    {
        Console.WriteLine($"Código: {Codigo}, Descripción: {Descripcion}, Depósito: {Deposito}, Disponible: {Disponible}");
    }

    //metodos para modificar la disponibilidad
    public void MarcarOcupado()
    {
        Disponible = false;
    }

    public void MarcarLibre()
    {
        Disponible = true;
    }
}