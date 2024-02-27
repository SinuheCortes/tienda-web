using Store.Api.Entitys;

namespace Store.Api.Data;

public class TiendaData
{
    public Tienda[] ObtenerTodo()
    {
        using var contexto = new ContextoTienda();
        return [.. contexto.Tienda];
    }

    public Tienda? ObtenerUnico(int id)
    {
        using var contexto = new ContextoTienda();
        return contexto.Tienda.Find(id);
    }

    public bool Guardar(Tienda tienda)
    {
        using var contexto = new ContextoTienda();
        contexto.Add(tienda);
        return contexto.SaveChanges() > 0;
    }

    public bool Actualizar(Tienda tienda)
    {
        using var contexto = new ContextoTienda();
        contexto.Update(tienda);
        return contexto.SaveChanges() > 0;
    }

    public bool Eliminar(Tienda tienda)
    {
        using var contexto = new ContextoTienda();
        contexto.Remove(tienda);
        return contexto.SaveChanges() > 0;
    }
}
