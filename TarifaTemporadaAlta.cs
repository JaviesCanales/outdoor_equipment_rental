class TarifaTemporadaAlta : TarifaEquipo
{
    //propiedas protegida
    protected double subtotal;
    protected double total;

    //metodo calculo si es temporada alta
    public override double Calcular(double dias, Equipo equipo)
    {
        subtotal = dias * equipo.Deposito;
        total = subtotal * 1.15;
        return total;
    }
}