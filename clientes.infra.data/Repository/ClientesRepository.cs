using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using clientes.infra.data.Mapping;
using Microsoft.Extensions.Configuration;

namespace clientes.infra.data.Repository
{
    public class ClientesRepository : IRepository<Cliente>
    {
        public IConfiguration Configuration { get; private set; }
        public SqlConnection Connection => new SqlConnection(ConfigurationExtensions.GetConnectionString(Configuration, "DefaultConnection"));
        public Guid Insert(Cliente entry)
        {
            string sql = @"
                INSERT INTO Cliente (Id, Nome, DataNascimento, CadastradoEm, Cpf, EnderecoId)
                VALUES('{0}', '{1}', '{2}', GETDATE(), '{3}', NULL);";

            sql = string.Format(sql, entry.Id, entry.Nome, entry.DataNascimento.ToString("dd/MM/yyyy"), entry.Cpf);

            using (var conn = Connection) {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Connection.Open();
                command.ExecuteNonQuery();

                return entry.Id;
            }
        }

        public Cliente Get(Guid id) {
            Cliente cliente = null;
            string sql = @"SELECT Id, Nome, DataNascimento, Cpf FROM Cliente WHERE Id = @Id";

            using (var conn = Connection) {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
                command.Parameters["@Id"].Value = id;

                try
                {
                    command.Connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new Cliente();
                            cliente.Id = reader.GetGuid(reader.GetOrdinal("Id"));
                            cliente.Nome = reader.GetString(reader.GetOrdinal("Nome"));
                            cliente.DataNascimento = reader.GetDateTime(reader.GetOrdinal("DataNascimento"));
                            cliente.Cpf = reader.GetString(reader.GetOrdinal("Cpf"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return cliente;
            }
        }
        public IEnumerable<Cliente> Get(int page, int length)
        {
            return new List<Cliente>();
        }
        public IEnumerable<Cliente> Get(int page, int length, string conditions)
        {
            IList<Cliente> clientes = new List<Cliente>();
            string sql = @"SELECT Id, Nome, DataNascimento, Cpf FROM Cliente WHERE " + conditions;

            using (var conn = Connection) {
                SqlCommand command = new SqlCommand(sql, conn);

                try
                {
                    command.Connection.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente();
                            cliente.Id = reader.GetGuid(reader.GetOrdinal("Id"));
                            cliente.Nome = reader.GetString(reader.GetOrdinal("Nome"));
                            cliente.DataNascimento = reader.GetDateTime(reader.GetOrdinal("DataNascimento"));
                            cliente.Cpf = reader.GetString(reader.GetOrdinal("Cpf"));

                            clientes.Add(cliente);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return clientes;
            }
        }
        public void Update(Cliente entry)
        {
            string sql = @"
                UPDATE Cliente SET
                    Nome = @Nome,
                    DataNascimento = @DataNascimento,
                    Cpf = @Cpf
                WHERE
                    Id = @Id;";

            using (var conn = Connection) {
                SqlCommand command = new SqlCommand(sql, conn);
                
                command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
                command.Parameters["@Id"].Value = entry.Id;
                
                command.Parameters.AddWithValue("@Nome", entry.Nome);
                command.Parameters.AddWithValue("@DataNascimento", entry.DataNascimento);
                command.Parameters.AddWithValue("@Cpf", entry.Cpf);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void Delete(Guid id)
        {
            string sql = @"DELETE FROM Cliente WHERE Id = @Id;";

            using (var conn = Connection) {
                SqlCommand command = new SqlCommand(sql, conn);
                
                command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier);
                command.Parameters["@Id"].Value = id;

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
