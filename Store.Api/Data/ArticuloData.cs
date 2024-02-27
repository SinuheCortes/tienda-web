using Microsoft.EntityFrameworkCore;
using Store.Api.Dtos;
using Store.Api.Entitys;

namespace Store.Api.Data;

public class ArticuloData
{
    private readonly ContextoTienda _contexto;
    public ArticuloData()
    {
        _contexto = new ContextoTienda();
    }

    public Articulo[] ObtenerTodo(int idTienda)
    {
        return [.. _contexto.ArticuloTienda.Where(articulo => articulo.IdTienda == idTienda)
            .Select(articulo => new Articulo()
            {
                Codigo = articulo.IdArticuloNavigation.Codigo,
                Descripcion = articulo.IdArticuloNavigation.Descripcion,
                Precio = articulo.IdArticuloNavigation.Precio,
                Stock = articulo.IdArticuloNavigation.Stock,
                Imagen = articulo.IdArticuloNavigation.Imagen,
            })];
    }

    public Articulo? ObtenerUnico(Guid id)
    {
        return _contexto.Articulos.Find(id);
    }

    public ArticuloTienda? ObtenerArticuloTienda(Guid id)
    {
        return _contexto.ArticuloTienda.FirstOrDefault(art => art.IdArticulo == id);
    }

    public bool Guardar(Articulo articulo, ArticuloTienda articuloTienda)
    {
        _contexto.Add(articulo);
        _contexto.ArticuloTienda.Add(articuloTienda);
        return _contexto.SaveChanges() > 0;
    }

    public bool Actualizar(Articulo articulo, ArticuloTienda articuloTienda)
    {
        _contexto.Update(articulo);
        _contexto.Update(articuloTienda);
        return _contexto.SaveChanges() > 0;
    }

    public bool Eliminar(Articulo articulo, ArticuloTienda articuloTienda)
    {
        _contexto.Remove(articuloTienda);
        _contexto.RemoveRange(articulo);
        return _contexto.SaveChanges() > 0;
    }
}
