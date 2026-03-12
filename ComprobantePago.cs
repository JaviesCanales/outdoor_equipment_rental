class ComprobantePago
{
    //proppiedades publica
    public double Cambio;
    public double MontoPagado;

    //pago simple
    public bool Pagar(double Monto)
    {
        MontoPagado = Monto;
        return true;
    }
    
    //pago tarjeta
    public bool Pagar(double Monto, string tarjeta)
    {
        if (tarjeta == null)
            return false;

        MontoPagado = Monto;
        return true;
    }

    //pago efectivo con cambio
    public bool Pagar(double Monto, double Efectivo)
    {
        if (Efectivo < Monto)
        {
            MontoPagado = Efectivo;
            return false;
        }
        
        MontoPagado = Efectivo;
        Cambio = Efectivo - Monto;
        return true;
    }
}