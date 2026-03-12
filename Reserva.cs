class Reserva
{
    //propiedades publicas con private set
    public string ID { get; private set; }
    public Cliente Cliente { get; private set; }

    public DateTime Desde { get; private set; }

    public DateTime Hasta { get; private set; }
    public List<Equipo> Equipo {get; private set; }
    public ComprobantePago Pago { get; private set; }
    public double Penalidad { get; private set; }

    //encapsulación de monto
    protected double monto;

    public double Monto
    {
        get { return monto; }
        set { monto = value; }
    }
    
    //propiedad estado
    protected EstadoReserva estado {get; private set; }

    public EstadoReserva Estado => estado;

    //enumeración de estados
    public enum EstadoReserva
    {
        Pendiente,
        Confirmada,
        Entregada,
        Devuelta,
        Cerrada,
        Cancelada
    }

    //constructor reserva
    public Reserva(string ID, Cliente Cliente, List<Equipo>Equipo, DateTime Desde, DateTime Hasta)
    {
            this.ID = Cliente.ID;
            this.Cliente = Cliente;
            this.Equipo = Equipo;
            this.Desde = Desde;
            this.Hasta = Hasta;

            estado = EstadoReserva.Pendiente;

            Pago = new ComprobantePago();

    }

    //metodo calcular monto con tarifa seleccionada, seguro opcional y cargo extra
    public void CalcularMonto(TarifaEquipo tarifa, bool incluirSeguro, double extra)
    {
        double subtotal = 0;
        double dias = (Hasta - Desde).Days;
        if (dias <= 0) dias = 1;

        foreach (var eq in Equipo)
        {
            subtotal += tarifa.Calcular(dias, eq);
        }

        if (incluirSeguro)
            subtotal *= 1.10;

        if (extra > 0)
            subtotal += extra;

        Monto = subtotal;
    }

    //metodo cambios de estados
    public void Confirmar()
    {
        if (Estado != EstadoReserva.Pendiente)
            throw new Exception("Solo reservas pendiente pueden confirmarse.");
        foreach (var eq in Equipo)
        {
            if (!eq.Disponible)
                throw new Exception("Un equipo ya está ocupado.");
        }
        foreach (var eq in Equipo)
            eq.MarcarOcupado();

        estado = EstadoReserva.Confirmada;
    }

    public void Entregar()
    {
        if (estado != EstadoReserva.Confirmada)
            throw new Exception("Solo reservas confirmadas pueden entregarse.");

        estado = EstadoReserva.Entregada;
    }

    public void Devolver(List<Equipo> equiposDevueltos, bool conDanio, int diasRetraso)
    {
        
        if (estado != EstadoReserva.Entregada)
            throw new Exception("Solo reservas entregadas pueden devolverse.");

        foreach (var eq in equiposDevueltos)
            eq.MarcarLibre();

        double penalidad = 0;
        

        if (conDanio)
            penalidad += 50;

        if (diasRetraso > 0)
            penalidad += diasRetraso * 15;

        Penalidad = penalidad;
        Monto += penalidad;

        if (equiposDevueltos.Count == Equipo.Count)
            estado = EstadoReserva.Devuelta;

    }

    public void Cerrar()
    {
        if (estado != EstadoReserva.Devuelta)
            throw new Exception("Solo reservas devueltas pueden cerrarse.");

        estado = EstadoReserva.Cerrada;
    }

    public void Cancelar()
    {
        foreach (var eq in Equipo)
            eq.MarcarLibre();

        estado = EstadoReserva.Cancelada;
    }
}