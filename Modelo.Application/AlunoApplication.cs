using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Application.Interface;
using Modelo.Domain;
using Modelo.Infra.Repositorio.Interfaces;

namespace Modelo.Application
{
    public class AlunoApplication : IAlunoApplication
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoApplication(IAlunoRepositorio alunoRepositorio) 
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public async Task<Aluno> BuscarAluno(int id)
        {
            try
            {
                return await _alunoRepositorio.BuscarAluno(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AdicionarAluno(Aluno aluno)
        {
            _alunoRepositorio.Adicionar(aluno);
        }
    }
}
