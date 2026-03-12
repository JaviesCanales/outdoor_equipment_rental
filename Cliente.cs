class Cliente
{
    //propiedades privadas
    private string nombre;
    private string id;
    private string telefono;

    //propiedades publicas con get set
    public string Nombre
    {
        get {return nombre;}
        set {nombre = value;}
    }

    public string ID
    {
        get{return id;}
        set{id = value;}
    }

    public string Telefono
    {
        get{return telefono;}
        set{telefono = value;}
    }

    //metodo constructor de cliente
    public Cliente(string ID, string Nombre, string Telefono)
    {
        this.ID = ID;
        this.Nombre = Nombre;
        this.Telefono = Telefono;
    }
}