      public void ValidarLogicaNegocio_Pago(Pago pago)
{
    // Validaciones de negocio
    if (pago.Monto <= 0)
    {
        throw new ArgumentException("El monto del pago debe ser mayor a cero.");
    }

    if (string.IsNullOrEmpty(pago.MetodoPago))
    {
        throw new ArgumentException("Debe especificarse el método de pago.");
    }

    // Puedes agregar más validaciones según tu lógica de negocio
}