using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Data.SqlClient;
using System.Data;
using Data.Repositories;

namespace Datos.Repositories.SQL
{
    public class BitacoraRepositorySQL : IBitacoraRepository
    {

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[bitacora] "
                + "(datos, fechaHora) "
                + "VALUES (@datos, @fechaHora)";
        }
        private static string SelectAll
        {
            get => "SELECT * FROM [dbo].[bitacora]";
        }
        #endregion

        private static string cnnApp = ApplicationSettings.Current.ConexionSQL;

        public void Add(Bitacora bitacora)
        {
            {
                using (SqlConnection sqlConn = new SqlConnection(cnnApp))
                {
                    try
                    {
                        sqlConn.Open();

                        using (SqlCommand cmd = new SqlCommand(InsertStatement, sqlConn))
                        {
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("datos", bitacora.datos);
                            cmd.Parameters.AddWithValue("fechaHora", bitacora.fechaHora);

                            cmd.ExecuteScalar();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        sqlConn.Close();
                    }
                }
            }
        }

        public Task<bool> InsertLog(Bitacora bitacora)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Bitacora>> IBitacoraRepository.GetAllLogs()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bitacora> GetAll()
        {
            try
            {
                List<Bitacora> movimientos = new List<Bitacora>();

                using (var dr = SqlHelper.ExecuteReader(SelectAll, CommandType.Text))
                {
                    Object[] values = new Object[dr.FieldCount];

                    while (dr.Read())
                    {
                        dr.GetValues(values);

                        Bitacora bitacora = new Bitacora();

                        bitacora.datos = values[1].ToString();
                        bitacora.fechaHora = Convert.ToDateTime(values[2]);

                        movimientos.Add(bitacora);
                    }
                }
                return movimientos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
