﻿using BusinessLogic.DTOs.Candidate;
using BusinessLogic.DTOs.ContactPerson;
using BusinessLogic.DTOs.Dependent;
using BusinessLogic.DTOs.ShopData;
using CommonSolution.Constants;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mappers
{
    public class CandidateMapper
    {

        public Candidate MapToEntity(CandidateCreationDTO dto)
        {
            if (dto == null)
                throw new Exception("No hay objeto para mapear");

            return new Candidate()
            {
                Number = dto.Number,
                Name = dto.Name,
                LastName = dto.Name,
                BirthDate = dto.BirthDate,
                PersonalDocument = dto.PersonalDocument,
                Gender = dto.Gender,
                MaritalStatus = dto.MaritalStatus,
                PersonalAddress = dto.PersonalAddress,
                Phone = dto.Phone,
                Condition = dto.Condition,
                Status = dto.Condition,
                IdDecisionSupport = dto.IdDecisionSupport,
            };
        }

        public CandidateCreationDTO MapToObject(Candidate entity)
        {
            if (entity == null)
                throw new Exception("No hay entidad para mapear");

            return new CandidateCreationDTO()
            {
                Number = entity.Number,
                Name = entity.Name,
                LastName = entity.Name,
                BirthDate = entity.BirthDate,
                PersonalDocument = entity.PersonalDocument,
                Gender = entity.Gender,
                MaritalStatus = entity.MaritalStatus,
                PersonalAddress = entity.PersonalAddress,
                Phone = entity.Phone,
                Condition = entity.Condition,
                Id = entity.Id,
                Status = entity.Condition,
                IdDecisionSupport = entity.IdDecisionSupport,
            };
        }

        public Candidate MapToEditEntity(CandidateCreationDTO dto, Candidate entity)
        {
            if (dto == null || entity == null)
                throw new Exception("No hay objeto/entidad para mapear");

            entity.Name = dto.Name;
            entity.LastName = dto.Name;
            entity.BirthDate = dto.BirthDate;
            entity.PersonalDocument = dto.PersonalDocument;
            entity.Gender = dto.Gender;
            entity.MaritalStatus = dto.MaritalStatus;
            entity.PersonalAddress = dto.PersonalAddress;
            entity.Phone = dto.Phone;
            entity.Condition = dto.Condition;
            entity.Status = dto.Condition;
            entity.Number = dto.Number;
            entity.IdDecisionSupport = dto.IdDecisionSupport;

            return entity;
        }

        public CandidateCreationDTO MapToObject(CandidateCreationFrontDTO frontDTO)
        {
            if (frontDTO == null)
                throw new Exception("No hay objeto/entidad para mapear");

            return new CandidateCreationDTO
            {

                Name = frontDTO.name,
                LastName = frontDTO.lastName,
                BirthDate = frontDTO.birthDate,
                PersonalDocument = frontDTO.personalDocument,
                Gender = frontDTO.Gender,
                MaritalStatus = frontDTO.MaritalStatus,
                PersonalAddress = frontDTO.personalAddress,
                Phone = frontDTO.phone,
                Condition = frontDTO.condition,
                Status = CStatus.enrolled,

                ContactPerson = new ContactPersonCreationDTO
                {
                    Name = frontDTO.cpName,
                    LastName = frontDTO.cpLastName,
                    Phone = frontDTO.cpPhone,
                    Bond = frontDTO.bond
                },
                ShopData = string.IsNullOrEmpty(frontDTO.cName) ? null : new ShopDataCreationDTO
                {

                    Name = frontDTO.cName,
                    Phone = frontDTO.cPhone,
                    Address = frontDTO.address,
                    Neighborhood = frontDTO.neighborhood,
                    ShopType = frontDTO.shopType,
                    Latitude = frontDTO.latitude.ToString(),
                    Longitude = frontDTO.longitude.ToString(),
                }


            };

        }

    }
}
