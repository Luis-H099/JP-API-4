using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Domain;

namespace Modelo.Infra.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        Task<Aluno> BuscarAluno(int id);
        void Adicionar(Aluno aluno);
        Task<int> EditarAluno(Aluno aluno);
        Task<int> ExcluirAluno(int id);
    }
}
