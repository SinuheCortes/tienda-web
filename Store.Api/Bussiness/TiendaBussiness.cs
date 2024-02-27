using Store.Api.Data;
using Store.Api.Entitys;

namespace Store.Api.Bussiness;

public class TiendaBussiness
{
    private readonly TiendaData _data;
    public TiendaBussiness()
    {
        _data = new TiendaData();
    }
    public Tienda[] ObtenerTodo()
    {
        return _data.ObtenerTodo();
    }

    public bool Guardar(Tienda tienda)
    {
        return _data.Guardar(tienda);
    }

    public bool Actualizar(int id, Tienda tienda)
    {
        Tienda? tiendaBd = _data.ObtenerUnico(id);
        if (tiendaBd is null)
        {
            return false;
        }
        tiendaBd.Sucursal = tienda.Sucursal;
        tiendaBd.Direccion = tienda.Direccion;
        return _data.Actualizar(tiendaBd);
    }

    public bool Eliminar(int id)
    {
        Tienda? tienda = _data.ObtenerUnico(id);
        if (tienda is null)
        {
            return false;
        }
        return _data.Eliminar(tienda);
    }
}
