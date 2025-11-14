using Dapper;
using Microsoft.Data.SqlClient;
using Modelo.Domain;
using Modelo.Infra.Repositorio.Interfaces;

namespace Modelo.Infra.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly DbConnectionFactory _connectionFactory;

        public AlunoRepositorio(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Aluno> BuscarAluno(int id)
        {
            using var connection = _connectionFactory.CreateConnection();

            string sql = "SELECT * FROM Aluno WHERE Id = @Id";

            return await connection.QueryFirstOrDefaultAsync<Aluno>(sql, new { Id = id });
        }

        public void Adicionar(Aluno aluno)
        {
            using var connection = new SqlConnection(_connectionFactory.CreateConnection().ConnectionString);
            connection.Open();

            var sql = @"
                INSERT INTO Aluno (Nome, Matricula, Cep, Endereco, Bairro, Cidade)
                VALUES (@Nome, @Matricula, @Cep, @Endereco, @Bairro, @Cidade)";

            connection.Execute(sql, aluno);
        }

        public async Task<int> EditarAluno(Aluno aluno)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"
                UPDATE Aluno
                SET Nome = @Nome,
                    Matricula = @Matricula,
                    Cep = @Cep,
                    Endereco = @Endereco,
                    Bairro = @Bairro,
                    Cidade = @Cidade
                WHERE Id = @Id";

            return await connection.ExecuteAsync(sql, aluno);
        }

        public async Task<int> ExcluirAluno(int id)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"DELETE FROM Aluno WHERE Id = @Id";

            return await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
