﻿using AutoMapper.Execution;
using BusinessLogic.DTOs.Dependent;
using BusinessLogic.Mappers;
using CommonSolution.Constants;
using DataAccess.Context;
using DataAccess.Models;

namespace BusinessLogic.DataModel.Repository
{
    public class DependentRepository
    {
        private readonly Agencia_8Context _context;
        private readonly DependentMapper _mapper;

        public DependentRepository(Agencia_8Context context)
        {
            this._context = context;
            this._mapper = new DependentMapper();
        }

        #region ADD

        public decimal AddDependent(DependentCreationDTO dto, UnitOfWork uow, decimal userId)
        {
            Dependent entity = _mapper.MapToEntity(dto);
            entity.AddRow = DateTime.Now;

            _context.Dependent.Add(entity);
            uow.LogRepository.LogDependent(entity, userId, CActions.add);

            return entity.Id;
        }

        public void AddDependentFact(DependentFactCreationFrontDTO dto)
        {
            DependentFact entity = _mapper.MapToEntity(dto);

            entity.AddRow = DateTime.Now;
            _context.DependentFact.Add(entity);
        }

        #endregion

        #region UPDATE

        public void UpdateDependent(DependentCreationDTO dependent, UnitOfWork uow, decimal userId)
        {
            Dependent entity = _context.Dependent.FirstOrDefault(x => x.Id == dependent.Id);

            entity = this._mapper.MapToEditEntity(dependent, entity);
            entity.UpdRow = DateTime.Now;
            entity.UpdUserId = userId;

            _context.Dependent.Update(entity);
            uow.LogRepository.LogDependent(entity, userId, CActions.edit);
        }


        #endregion

        #region DELETE

        public void DeleteDependent(decimal id, UnitOfWork uow, decimal userId)
        {
            Dependent entity = _context.Dependent.FirstOrDefault(x => x.Id == id);

            entity.ActiveFlag = "N";
            entity.UpdRow = DateTime.Now;
            _context.Dependent.Update(entity);

            uow.LogRepository.LogDependent(entity, userId, CActions.delete);
        }

        #endregion

        #region ANY
        public bool ExistDependentByNumber(decimal number)
        {
            return _context.Dependent.Any(x => x.Number == number);
        }

        public bool ExistDependentById(decimal id)
        {
            return _context.Dependent.Any(x => x.Id == id);
        }

        #endregion

        #region GET
        public DependentCreationFrontDTO GetDependentCompleteById(int id)
        {
            var x = _context.VDependent.FirstOrDefault(x => x.Id == id);
            return _mapper.MapToEditObject(x);
        }

        public IQueryable<VDependent> GetDependents()
        {
            return _context.VDependent.AsQueryable();
        }

        public IQueryable<VExCandidateDependent> GetExCandidateDependents()
        {
            return _context.VExCandidateDependent.AsQueryable();
        }

        #endregion

    }
}
