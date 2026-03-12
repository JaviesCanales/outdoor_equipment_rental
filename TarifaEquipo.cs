class TarifaEquipo
{
    //metodo para calcular dias por equipo
    public virtual double Calcular(double dias, Equipo equipo)
    {
        return dias * equipo.Deposito;
    }

}