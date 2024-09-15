using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            ArticuloDatos datos = new ArticuloDatos();
            List<Articulo> Lista = new List<Articulo>();

            try
            {
                datos.Consulta("\r\nSELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.ImagenUrl, A.Precio, A.IdMarca, A.IdCategoria FROM ARTICULOS A, MARCAS M, CATEGORIAS C WHERE M.Id = A.IdMarca AND C.Id = A.IdCategoria;\r\n\r\n");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                   
                    aux.Precio = (decimal)datos.Lector["Precio"];
                   
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (String)datos.Lector["ImagenUrl"];
                    }

                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];


                    Lista.Add(aux);

                }
                datos.CerrarConexion();
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Articulo> Filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> Lista = new List<Articulo>();
            ArticuloDatos datos = new ArticuloDatos();

            try
            {
                string consulta = "\r\nSELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.ImagenUrl, A.Precio, A.IdMarca, A.IdCategoria FROM ARTICULOS A, MARCAS M, CATEGORIAS C WHERE M.Id = A.IdMarca AND C.Id = A.IdCategoria AND ";

                if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Codigo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Codigo like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Codigo like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Codigo like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "M.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "M.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "M.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Categoria")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "C.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "C.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "C.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.Consulta(consulta);
                datos.ejecutarConsulta();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    }

                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];

                    Lista.Add(aux);
                }

                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Agregar(Articulo nuevo)
        {
            ArticuloDatos agregar = new ArticuloDatos();
            string consulta = "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) VALUES (@Cod, @Nom, @Desc, @IdM, @IdC, @ImgUrl, @Pre)";

            try
            {
                agregar.Consulta(consulta);
                agregar.SetearParametro("@Cod", nuevo.Codigo);
                agregar.SetearParametro("@Nom", nuevo.Nombre);
                agregar.SetearParametro("@Desc", nuevo.Descripcion);
                agregar.SetearParametro("@ImgUrl", nuevo.ImagenUrl);
                agregar.SetearParametro("@IdM", nuevo.Marca.IdMarca);
                agregar.SetearParametro("@Pre", nuevo.Precio);
                agregar.SetearParametro("@IdC", nuevo.Categoria.IdCategoria);
                agregar.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Modificar(Articulo articulo)
        {
            ArticuloDatos datos = new ArticuloDatos();

            try
            {
                string consulta = "UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio WHERE Id = @Id";

                datos.Consulta(consulta);
                datos.SetearParametro("@Codigo", articulo.Codigo);
                datos.SetearParametro("@Nombre", articulo.Nombre);
                datos.SetearParametro("@Descripcion", articulo.Descripcion);
                datos.SetearParametro("@IdMarca", articulo.Marca.IdMarca);
                datos.SetearParametro("@Precio", articulo.Precio);
                datos.SetearParametro("@IdCategoria", articulo.Categoria.IdCategoria);
                datos.SetearParametro("@ImagenUrl", articulo.ImagenUrl);
                datos.SetearParametro("@Id", articulo.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                ArticuloDatos datos = new ArticuloDatos();
                datos.Consulta("delete from Articulos where id = @id");
                datos.SetearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
