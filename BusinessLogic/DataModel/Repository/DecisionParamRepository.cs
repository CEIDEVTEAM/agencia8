﻿using BusinessLogic.DTOs.DecisionParam;
using BusinessLogic.DTOs.Dependent;
using BusinessLogic.Mappers;
using CommonSolution.Constants;
using DataAccess.Context;
using DataAccess.Models;

namespace BusinessLogic.DataModel.Repository
{
    public class DecisionParamRepository
    {
        private readonly Agencia_8Context _context;
        private readonly DecisionParamMapper _mapper;

        public DecisionParamRepository(Agencia_8Context context)
        {
            this._context = context;
            this._mapper = new DecisionParamMapper();
        }

        #region ADD


        #endregion

        #region UPDATE

        public void UpdateDecisionParam(DecisionParamCreationDTO decisionParam, UnitOfWork uow)
        {
            DecisionParam entity = this.GetDecisionParamById(decisionParam.Id);

            entity = this._mapper.MapToEditEntity(decisionParam, entity);
            entity.UpdRow = DateTime.Now;

            _context.DecisionParam.Update(entity);
        }


        #endregion

        #region DELETE


        #endregion

        #region ANY
        public bool ExistDecisionParamById(decimal id)
        {
            return _context.DecisionParam.Any(x => x.Id == id);
        }

        #endregion

        #region GET

        public IQueryable<DecisionParam> GetDecisionParams()
        {
            return _context.DecisionParam.AsQueryable();
        }

        public DecisionParam GetDecisionParamById(decimal id)
        {
            return _context.DecisionParam.FirstOrDefault(x => x.Id == id);
        }

        #endregion

    }
}