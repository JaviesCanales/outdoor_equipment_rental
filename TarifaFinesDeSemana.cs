class TarifaFinDeSemana : TarifaEquipo
{
    //propiedades protegido
    protected double subtotal;
    protected double total;
    protected double extra;

    //encapsulación
    public double Extra
    {
        get { return extra; }
        set { extra = value; }
    }
    //metodo calculo para añadir cargos extra de fin de semana
    public override double Calcular(double dias, Equipo equipo)
    {
        subtotal = dias * equipo.Deposito;
        total = subtotal + Extra;
        return total;
    }
}